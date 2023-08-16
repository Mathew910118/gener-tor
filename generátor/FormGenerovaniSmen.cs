using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;

namespace generátor
{
    public partial class FormGenerovaniSmen : Form
    {
        private List<Policista> seznamPolicistu;
        private List<string> povoleneRole;
        private ComboBox cmbYear;
        private ComboBox cmbMonth;


        public FormGenerovaniSmen()
        {
            InitializeComponent();

            seznamPolicistu = new List<Policista>();
            povoleneRole = new List<string> { "prvosled denní", "prvosled noční", "kyselka denní", "kyselka noční", "hlídkař", "zpracovatel", "okrskář", "pomocník", "dozorčí denní", "dozorčí noční" };

            // Initialize ComboBoxes for year and month selection
            cmbYear = new ComboBox();
            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYear.Items.AddRange(Enumerable.Range(DateTime.Now.Year - 10, 20).Select(year => year.ToString()).ToArray());
            cmbYear.SelectedIndex = 10; // Default selection to current year
            cmbYear.Location = new Point(10, 10); // Adjust the location as needed
            this.Controls.Add(cmbYear);

            cmbMonth = new ComboBox();
            cmbMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMonth.Items.AddRange(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.Take(12).ToArray());
            cmbMonth.SelectedIndex = DateTime.Now.Month - 1; // Default selection to current month
            cmbMonth.Location = new Point(150, 10); // Adjust the location as needed
            this.Controls.Add(cmbMonth);

            cmbYear.SelectedIndexChanged += new EventHandler(cmbMonth_SelectedIndexChanged);
            cmbMonth.SelectedIndexChanged += new EventHandler(cmbMonth_SelectedIndexChanged);

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;

        }

        private bool NacistDataZeSouboru()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Textové soubory (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        seznamPolicistu.Clear();
                        using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                        {
                            while (!sr.EndOfStream)
                            {
                                string radek = sr.ReadLine();
                                string[] hodnoty = radek.Split(',');

                                string jmeno = hodnoty[0];
                                string hodnost = hodnoty[1];
                                List<string> role = hodnoty[2].Split(',').Select(r => r.Trim()).ToList();

                                seznamPolicistu.Add(new Policista(jmeno, hodnost, role));
                            }
                        }

                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chyba při načítání souboru: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return false;
        }

        private double CalculateTotalHours(int year, int month)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);
            int saturdays = Enumerable.Range(1, daysInMonth)
                                      .Count(d => new DateTime(year, month, d).DayOfWeek == DayOfWeek.Saturday);
            int sundays = Enumerable.Range(1, daysInMonth)
                                    .Count(d => new DateTime(year, month, d).DayOfWeek == DayOfWeek.Sunday);
            double totalHours = (daysInMonth - saturdays - sundays) * 7.5;
            return totalHours;
        }


        private void ZobrazitDataVDataGridView()
        {
            dataGridView1.Rows.Clear();

            int selectedYear = int.Parse(cmbYear.SelectedItem.ToString());
            int selectedMonth = cmbMonth.SelectedIndex + 1;

            foreach (Policista policista in seznamPolicistu)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                row.Cells[0].Value = policista.Jmeno;
                row.Cells[1].Value = policista.Hodnost;

                double totalHours = CalculateTotalHours(selectedYear, selectedMonth);
                row.Cells[2].Value = totalHours;

                
                dataGridView1.Rows.Add(row);
            }

            RozdeleniSluzebProDulezite(selectedMonth); // Volání funkce pro rovnoměrné rozdělení čísla 60
            CalculateAndDisplaySum(); // Volání funkce pro výpočet a zobrazení sumy
            SecteniHodnotVRadku();
        }

        private void RozdeleniSluzebProDulezite(int selectedMonth)
        {
            int cislo60 = DateTime.DaysInMonth(DateTime.Now.Year, selectedMonth) * 2;

            for (int columnIndex = 3; columnIndex < 9; columnIndex++)
            {
                if (columnIndex == 7 || columnIndex == 8)
                {
                    cislo60 = DateTime.DaysInMonth(DateTime.Now.Year, selectedMonth);
                }

                string role = dataGridView1.Columns[columnIndex].HeaderText.ToLower();

                // Filtrujeme seznam policistů, kteří mají danou roli.
                var policisteSRoli = seznamPolicistu.Where(p => p.Role.Any(r => r.Split(';').Any(part => part.Trim().ToLower() == role))).ToList();

                int pocetPolicistuSRoli = policisteSRoli.Count;

                if (pocetPolicistuSRoli == 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        row.Cells[columnIndex].Value = "N/A";
                        row.Cells[columnIndex].ReadOnly = true;
                    }
                    continue;
                }

                int zaokrouhlenyPrumerNahoru = (int)Math.Ceiling((double)cislo60 / pocetPolicistuSRoli);
                int zaokrouhlenyPrumerDolu = (int)Math.Floor((double)cislo60 / pocetPolicistuSRoli);

                int pocetPolicistuNahoru = cislo60 % pocetPolicistuSRoli; // Zbytkový operátor nám dává počet policistů s hodnotou nahoru.

                int rozdeleno = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value == null) continue;

                    string jmeno = row.Cells[0].Value.ToString();
                    Policista policista = policisteSRoli.Find(p => p.Jmeno == jmeno);

                    if (policista != null)
                    {
                        row.Cells[columnIndex].Value = rozdeleno < pocetPolicistuNahoru ? zaokrouhlenyPrumerNahoru : zaokrouhlenyPrumerDolu;
                        rozdeleno++;
                    }
                    else
                    {
                        row.Cells[columnIndex].Value = "N/A";
                        row.Cells[columnIndex].ReadOnly = true;
                    }
                }
            }
        }


        private void CalculateAndDisplaySum()
        {
            int rowCount = dataGridView1.Rows.Count;

            for (int columnIndex = 3; columnIndex <= 8; columnIndex++) // sloupce 4 až 10
            {
                double sum = 0;
                for (int rowIndex = 0; rowIndex < rowCount - 1; rowIndex++) // poslední řádek je pro součet
                {
                    if (dataGridView1.Rows[rowIndex].Cells[columnIndex].Value != null)
                    {
                        double cellValue;
                        if (double.TryParse(dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString(), out cellValue))
                        {
                            sum += cellValue;
                        }
                    }
                }
                dataGridView1.Rows[rowCount - 1].Cells[columnIndex].Value = sum;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CalculateAndDisplaySum();
        }






        private void btnNacistData_Click(object sender, EventArgs e)
        {
            if (NacistDataZeSouboru())
            {
                ZobrazitDataVDataGridView();
            }
        }

        private void btnUlozitDoExcelu_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (saveFileDialog.FilterIndex == 1)
                        {
                            // Ukládání do Excelu
                            FileInfo newFile = new FileInfo(saveFileDialog.FileName);
                            using (ExcelPackage package = new ExcelPackage(newFile))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                                // Uložte hlavičky sloupců
                                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                                {
                                    worksheet.Cells[1, i + 1].Value = dataGridView1.Columns[i].HeaderText;
                                }

                                // Uložte data z DataGridView
                                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                                {
                                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                                    {
                                        if (dataGridView1.Rows[row].Cells[col].Value != null)
                                        {
                                            worksheet.Cells[row + 2, col + 1].Value = dataGridView1.Rows[row].Cells[col].Value.ToString();
                                        }
                                    }
                                }

                                package.Save();
                            }

                            MessageBox.Show("Data byla úspěšně uložena do Excelu.", "Úspěch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (saveFileDialog.FilterIndex == 2)
                        {
                            // Ukládání do CSV
                            string csvContent = "Jmeno;Hodnost;Pocet hodin;Role" + Environment.NewLine;

                            for (int row = 0; row < dataGridView1.Rows.Count; row++)
                            {
                                string jmeno = dataGridView1.Rows[row].Cells["Jmeno"].Value?.ToString() ?? "";
                                string hodnost = dataGridView1.Rows[row].Cells["Hodnost"].Value?.ToString() ?? "";
                                string pocetHodin = dataGridView1.Rows[row].Cells["PocetHodin"].Value?.ToString() ?? "";

                                // Získání seznamu rolí policisty s číslem, kde hodnota je větší nebo rovna 0
                                List<Tuple<string, int>> roleList = new List<Tuple<string, int>>();
                                foreach (DataGridViewColumn column in dataGridView1.Columns.Cast<DataGridViewColumn>().Skip(3))
                                {
                                    if (dataGridView1.Rows[row].Cells[column.Index].Value != null)
                                    {
                                        int pocetSluzeb;
                                        if (int.TryParse(dataGridView1.Rows[row].Cells[column.Index].Value.ToString(), out pocetSluzeb))
                                        {
                                            if (pocetSluzeb >= 0)
                                            {
                                                roleList.Add(new Tuple<string, int>(column.HeaderText, pocetSluzeb));
                                            }
                                        }
                                    }
                                }

                                // Vytvoření řetězce pro CSV s informacemi o policistovi
                                string roleCSV = string.Join(",", roleList.Select(role => $"{role.Item1}({role.Item2})"));
                                string csvRow = $"{jmeno};{hodnost};{pocetHodin};{roleCSV}" + Environment.NewLine;
                                csvContent += csvRow;
                            }

                            File.WriteAllText(saveFileDialog.FileName, csvContent);

                            MessageBox.Show("Data byla úspěšně uložena do CSV souboru.", "Úspěch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chyba při ukládání dat: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void BtnGenerovatSluzbyNaCelyMesic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Get selected year and month
                        int selectedYear = int.Parse(cmbYear.SelectedItem.ToString());
                        int selectedMonth = cmbMonth.SelectedIndex + 1; // ComboBox uses 0-based indexing

                        // Načtení dat ze souboru CSV s oddělovačem středníkem
                        DataTable dataTable = new DataTable();
                        using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                        {
                            string[] headers = sr.ReadLine().Split(';'); // Použijeme středník jako oddělovač
                            for (int i = 0; i < 4 && i < headers.Length; i++) // Omezíme se na první tři sloupce z CSV
                            {
                                dataTable.Columns.Add(headers[i]);
                            }

                            while (!sr.EndOfStream)
                            {
                                string[] rows = sr.ReadLine().Split(';'); // Použijeme středník jako oddělovač
                                DataRow dataRow = dataTable.NewRow();
                                for (int i = 0; i < 4 && i < rows.Length; i++) // Omezíme se na první tři sloupce z CSV
                                {
                                    dataRow[i] = rows[i];
                                }
                                dataTable.Rows.Add(dataRow);
                            }
                        }

                        int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);

                        FileInfo newFile = new FileInfo("Generated_Schedule.xlsx");
                        using (ExcelPackage package = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                            // Uložte hlavičky sloupců do Excelu
                            worksheet.Cells[1, 1].Value = "Jmeno policisty";
                            worksheet.Cells[1, 2].Value = "Hodnost";
                            worksheet.Cells[1, 3].Value = "Pocet hodin";
                            worksheet.Cells[1, 4].Value = "Role";

                            // Získání všech dnů v zvoleném měsíci a uložení do Excelu
                            DateTime firstDayOfMonth = new DateTime(selectedYear, selectedMonth, 1);
                            for (int i = 0; i < daysInMonth; i++)
                            {
                                worksheet.Cells[1, i + 5].Value = firstDayOfMonth.AddDays(i).ToShortDateString();
                            }

                            // Formátování datových buněk na text, abychom zachovali datum v původním formátu
                            for (int i = 4; i < daysInMonth + 4; i++)
                            {
                                using (ExcelRange range = worksheet.Cells[1, i])
                                {
                                    range.Style.Numberformat.Format = "@";
                                }
                            }

                            // Uložení dat ze souboru CSV do Excelu
                            for (int row = 0; row < dataTable.Rows.Count; row++)
                            {
                                for (int col = 0; col < dataTable.Columns.Count; col++)
                                {
                                    worksheet.Cells[row + 2, col + 1].Value = dataTable.Rows[row][col].ToString();
                                }
                            }

                            // Označení policistů s rolí "prvosled" do sloupce "Role" v den 1
                            OzancitPrvosledPolicisty(dataTable, worksheet);

                            // Uložení souboru
                            package.Save();
                        }

                        MessageBox.Show("Data byla úspěšně vygenerována a uložena do Excelu.", "Úspěch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chyba při generování a ukládání dat do Excelu: " + ex.Message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void OzancitPrvosledPolicisty(DataTable dataTable, ExcelWorksheet worksheet)
        {
            // Projděte každý den v měsíci
            for (int day = 0; day < DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month); day++)
            {
                // Nalezneme 2 policisty s rolí "prvosled" z DataTable
                var prvosledRows = dataTable.AsEnumerable().Where(row => row.Field<string>(3) == "prvosled denní").Take(2).ToList();

                foreach (var row in prvosledRows)
                {
                    // Získejte index řádku z DataTable
                    int rowIndex = dataTable.Rows.IndexOf(row);

                    // Nastavíme hodnotu v Excelu pro označení policisty s rolí "prvosled"
                    worksheet.Cells[rowIndex + 2, day + 5].Value = "Prvosled denní";
                }

                // Pokud byli nalezeni 2 policisté s rolí "prvosled", odstraníme je z DataTable, aby nebyli znovu zvoleni
                if (prvosledRows.Count == 2)
                {
                    dataTable.Rows.Remove(prvosledRows[0]);
                    dataTable.Rows.Remove(prvosledRows[1]);
                }
            }
        }



        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ZobrazitDataVDataGridView();
        }

        private void SecteniHodnotVRadku()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                double total = 0;

                if (row.Cells[3].Value != null && row.Cells[3].Value.ToString() != "N/A")
                {
                    total += Convert.ToDouble(row.Cells[3].Value) * 12.5;
                }

                if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "N/A")
                {
                    total += Convert.ToDouble(row.Cells[4].Value) * 12.5;
                }

                if (row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "N/A")
                {
                    total += Convert.ToDouble(row.Cells[5].Value) * 11;
                }

                if (row.Cells[6].Value != null && row.Cells[6].Value.ToString() != "N/A")
                {
                    total += Convert.ToDouble(row.Cells[6].Value) * 11;
                }

                if (row.Cells[7].Value != null && row.Cells[7].Value.ToString() != "N/A")
                {
                    total += Convert.ToDouble(row.Cells[7].Value) * 12;
                }

                if (row.Cells[8].Value != null && row.Cells[8].Value.ToString() != "N/A")
                {
                    total += Convert.ToDouble(row.Cells[8].Value) * 7.5;
                }

                if (row.Cells[9].Value != null && row.Cells[9].Value.ToString() != "N/A")
                {
                    total += Convert.ToDouble(row.Cells[9].Value) * 7.5;
                }

                if (row.Cells[10].Value != null && row.Cells[10].Value.ToString() != "N/A")
                {
                    total += Convert.ToDouble(row.Cells[10].Value) * 10;
                }

                if (row.Cells[11].Value != null && row.Cells[11].Value.ToString() != "N/A")
                {
                    total += Convert.ToDouble(row.Cells[11].Value) * 9.5;
                }

                if (row.Cells[2].Value != null && double.TryParse(row.Cells[2].Value.ToString(), out double hodnotaSloupce2))
                {
                    total -= hodnotaSloupce2;
                }

                row.Cells[14].Value = total;
            }
        }

        private void btnManageShifts_Click(object sender, EventArgs e)
        {
            ManageShiftsForm manageShiftsForm = new ManageShiftsForm(seznamPolicistu);
            manageShiftsForm.ShowDialog(); // Použijte Show() místo ShowDialog(), pokud chcete okno nemodální.
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                ExcelWorksheet ws = excel.Workbook.Worksheets.Add("Směny");



                // Zapíše policisty a jejich hodnosti
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    ws.Cells[i + 2, 1].Value = dataGridView1.Rows[i].Cells["Jmeno"].Value;
                    ws.Cells[i + 2, 2].Value = dataGridView1.Rows[i].Cells["Hodnost"].Value;
                }

                // Zapíše aktuální rok a měsíc nad dny
                DateTime now = DateTime.Now;
                int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);
                int middleDayColumn = daysInMonth / 2 + 2;  // vypočítáme střední sloupec

                ws.Cells[1, middleDayColumn].Value = now.ToString("MMMM yyyy", new System.Globalization.CultureInfo("cs-CZ"));

                // Změníme velikost písma pro název měsíce a roku
                ws.Cells[1, middleDayColumn].Style.Font.Size = 14;
                ws.Cells[1, middleDayColumn].Style.Font.Bold = true;

                // Pro lepší vizuální efekt spojíme několik buněk pro název měsíce a roku
                ws.Cells[1, middleDayColumn - 1, 1, middleDayColumn + 1].Merge = true;
                ws.Cells[1, middleDayColumn - 1, 1, middleDayColumn + 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                // Názvy sloupců: "Jména", "Hodnosti", a dny v měsíci
                ws.Cells[2, 1].Value = "Jména";
                ws.Cells[2, 2].Value = "Hodnosti";

                // Zapíše dny v měsíci
                for (int i = 1; i <= daysInMonth; i++)
                {
                    ws.Cells[2, i + 2].Value = $"{i}. {now.ToString("MM")}";  // Vypíše den a měsíc (např. "1. 01")
                }

                // Uložení souboru
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    FileName = "output.xlsx",
                    Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                    Title = "Uložit Excel soubor"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create);
                    excel.SaveAs(stream);
                    stream.Close();
                    MessageBox.Show("Export do Excelu byl úspěšný!");
                }
            }
        }

    }
}
