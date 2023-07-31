using System;
using System.Collections.Generic;
using System.Data;
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

        public FormGenerovaniSmen()
        {
            InitializeComponent();

            seznamPolicistu = new List<Policista>();
            povoleneRole = new List<string> { "prvosled", "kyselka", "hlídkař", "zpracovatel", "okrskář", "pomocník", "dozorčí" };
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

        private void ZobrazitDataVDataGridView()
        {
            dataGridView1.Rows.Clear();

            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            foreach (Policista policista in seznamPolicistu)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1);

                // Zobrazit jméno a hodnost
                row.Cells[0].Value = policista.Jmeno;
                row.Cells[1].Value = policista.Hodnost;

                // Vypočítat počet hodin, které má odpracovat
                int daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);
                int saturdays = Enumerable.Range(1, daysInMonth)
                                          .Count(d => new DateTime(currentYear, currentMonth, d).DayOfWeek == DayOfWeek.Saturday);
                int sundays = Enumerable.Range(1, daysInMonth)
                                        .Count(d => new DateTime(currentYear, currentMonth, d).DayOfWeek == DayOfWeek.Sunday);
                double totalHours = (daysInMonth - saturdays - sundays) * 7.5;
                row.Cells[2].Value = totalHours;

                // Zobrazit počty služeb pro každou roli
                foreach (DataGridViewColumn column in dataGridView1.Columns.Cast<DataGridViewColumn>().Skip(3))
                {
                    string role = column.HeaderText;
                    bool maRoli = policista.Role.Any(r => r.Split(';').Select(x => x.Trim().ToLower()).Contains(role.ToLower()));

                    if (maRoli && povoleneRole.Contains(role.ToLower()))
                    {
                        // Pokud má policista roli, zobrazíme 0
                        row.Cells[column.Index].Value = 0;
                    }
                    else
                    {
                        // Pokud nemá roli nebo je role zakázaná, zobrazíme "N/A" a buňku nastavíme jako neaktivní
                        row.Cells[column.Index].Value = "N/A";
                        row.Cells[column.Index].ReadOnly = true;
                    }
                }

                dataGridView1.Rows.Add(row);
            }
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

                        int month = DateTime.Now.Month;
                        int year = DateTime.Now.Year;
                        int daysInMonth = DateTime.DaysInMonth(year, month);

                        FileInfo newFile = new FileInfo("Generated_Schedule.xlsx");
                        using (ExcelPackage package = new ExcelPackage(newFile))
                        {
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                            // Uložte hlavičky sloupců do Excelu
                            worksheet.Cells[1, 1].Value = "Jmeno policisty";
                            worksheet.Cells[1, 2].Value = "Hodnost";
                            worksheet.Cells[1, 3].Value = "Pocet hodin";
                            worksheet.Cells[1, 4].Value = "Role";

                            // Získání všech dnů v aktuálním měsíci a uložení do Excelu
                            DateTime firstDayOfMonth = new DateTime(year, month, 1);
                            DateTime lastDayOfMonth = new DateTime(year, month, daysInMonth);
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
            int dayColumnStartIndex = 5; // Index sloupce, od kterého začínají dny (5. sloupec v Excelu)
            int maxPolicistsPerDay = 4; // Maximální počet policistů na den
            int maxPolicistsPerType = 2; // Maximální počet policistů pro každý typ služby (denní, noční)

            // Seznam policistů pro denní službu a noční službu
            List<string> denniSluzbaPoliciste = new List<string>();
            List<string> nocniSluzbaPoliciste = new List<string>();

            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Projdeme všechny dny v měsíci a generujeme služby pro každý den
            for (int day = 1; day <= daysInMonth; day++)
            {
                // Projdeme všechny řádky datové tabulky
                for (int row = 0; row < dataTable.Rows.Count; row++)
                {
                    // Získáme hodnotu ze sloupce "Role" pro aktuální řádek
                    string role = dataTable.Rows[row]["Role"].ToString();

                    // Rozdělíme roli pomocí čárky na jednotlivé role
                    string[] roleList = role.Split(',');

                    // Zkontrolujeme, zda obsahuje roli "Prvosled"
                    bool hasPrvosled = roleList.Any(r => r.Trim() == "Prvosled");

                    // Pokud má roli "Prvosled", rozdělíme denní službu a noční službu mezi policisty
                    if (hasPrvosled)
                    {
                        string jmeno = dataTable.Rows[row]["Jmeno"].ToString();
                        string hodnost = dataTable.Rows[row]["Hodnost"].ToString();
                        double pocetHodin = Convert.ToDouble(dataTable.Rows[row]["Pocet hodin"].ToString());

                        // Pokud policista má ještě nějaké hodiny, které mu zbývá odsloužit, rozdělíme službu
                        if (pocetHodin > 0)
                        {
                            // Rozdělení denní služby a noční služby mezi čtyři policisty
                            if (denniSluzbaPoliciste.Count < maxPolicistsPerDay && denniSluzbaPoliciste.Count < maxPolicistsPerType)
                            {
                                denniSluzbaPoliciste.Add($"{jmeno} ({hodnost})");
                                worksheet.Cells[row + 2, dayColumnStartIndex + day - 1].Value = "Denni sluzba";
                                pocetHodin -= 12.5; // Odpočítáme 12.5 hodiny od denní služby
                                if (pocetHodin < 12) pocetHodin = 0; // Pokud zbyde méně než 0 hodin, nastavíme 0
                            }
                            else if (nocniSluzbaPoliciste.Count < maxPolicistsPerDay && nocniSluzbaPoliciste.Count < maxPolicistsPerType)
                            {
                                nocniSluzbaPoliciste.Add($"{jmeno} ({hodnost})");
                                worksheet.Cells[row + 2, dayColumnStartIndex + day - 1].Value = "Nocni sluzba";
                                pocetHodin -= 12.5; // Odpočítáme 12.5 hodiny od noční služby
                                if (pocetHodin < 12) pocetHodin = 0; // Pokud zbyde méně než 0 hodin, nastavíme 0
                            }

                            // Aktualizujeme hodnotu v tabulce "Pocet hodin" po odečtení odpracovaných hodin
                            dataTable.Rows[row]["Pocet hodin"] = pocetHodin.ToString();
                        }
                    }
                }

                // Vyprázdnění seznamů pro denní a noční službu po dokončení generování pro jeden den
                denniSluzbaPoliciste.Clear();
                nocniSluzbaPoliciste.Clear();
            }
        }


        private DataTable GeneratePrvosledSchedule(DataTable dataTable, int daysInMonth)
        {
            // Vytvoření nové tabulky pro výsledné plánování
            DataTable scheduleTable = new DataTable();
            scheduleTable.Columns.Add("Jmeno policisty");
            scheduleTable.Columns.Add("Hodnost");
            scheduleTable.Columns.Add("Pocet hodin");

            // Počet denních služeb a nočních služeb pro jednoho policistu
            int dailyServicesPerMonth = daysInMonth / 2; // Celkový počet dní v měsíci je rozdělen na polovinu pro denní a noční služby

            // Seznam policistů s rolí "Prvosled"
            List<DataRow> prvoslouziPoliciste = new List<DataRow>();
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Role"].ToString().Contains("Prvosled"))
                {
                    prvoslouziPoliciste.Add(row);
                }
            }

            // Počet policistů s rolí "Prvosled"
            int pocetPrvosledPolicistu = prvoslouziPoliciste.Count;

            // Počet policistů pro denní a noční službu (2 denní a 2 noční)
            int pocetPolicistuDenniSluzba = pocetPrvosledPolicistu / 2;
            int pocetPolicistuNocniSluzba = pocetPrvosledPolicistu - pocetPolicistuDenniSluzba;

            // Kontrola, zda lze plánovat denní a noční služby
            if (pocetPolicistuDenniSluzba < 2 || pocetPolicistuNocniSluzba < 2)
            {
                throw new Exception("Nedostatek policistů s rolí 'Prvosled' pro plánování denních a nočních služeb.");
            }

            // Generování sloupců pro policisty s rolí "Prvosled" podle pravidel
            foreach (DataRow row in prvoslouziPoliciste)
            {
                string jmeno = row["Jmeno"].ToString();
                string hodnost = row["Hodnost"].ToString();
                string pocetHodin = row["Pocet hodin"].ToString();

                DataRow scheduleRow = scheduleTable.NewRow();
                scheduleRow["Jmeno policisty"] = jmeno;
                scheduleRow["Hodnost"] = hodnost;
                scheduleRow["Pocet hodin"] = pocetHodin;

                // Generování sloupců pro denní a noční službu pro policistu
                int pocetDenniSluzby = 0;
                int pocetNocniSluzby = 0;

                for (int i = 0; i < daysInMonth; i++)
                {
                    // Podle pravidel zajistíme, že každý den budou 4 policisté v práci (2 denní a 2 noční služby)
                    if (pocetDenniSluzby < dailyServicesPerMonth / 2)
                    {
                        scheduleRow[i + 3] = "Denni sluzba";
                        pocetDenniSluzby++;
                    }
                    else if (pocetNocniSluzby < dailyServicesPerMonth / 2)
                    {
                        scheduleRow[i + 3] = "Nocni sluzba";
                        pocetNocniSluzby++;
                    }
                    else
                    {
                        scheduleRow[i + 3] = "Volno";
                    }
                }

                scheduleTable.Rows.Add(scheduleRow);
            }

            return scheduleTable;
        }

    }
}
