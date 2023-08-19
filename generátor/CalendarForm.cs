using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generátor
{
    public partial class CalendarForm : Form
    {
        private List<DateTime> selectedDates = new List<DateTime>();
        private DataGridView dataGridView = new DataGridView();
        private List<int> selectedDays = new List<int>();
        private List<int> preselectedDays;
        private int selectedYear;
        private int selectedMonth;




        public CalendarForm(List<int> daysToSelect, int year, int month)
        {
            InitializeComponent();
            preselectedDays = daysToSelect;
            selectedYear = year;
            selectedMonth = month;
            SetupCalendar();
        }


        private void SetupCalendar()
        {
            dataGridView.Dock = DockStyle.Fill;
            this.Controls.Add(dataGridView);
            DateTime startOfMonth = new DateTime(selectedYear, selectedMonth, 1);
            DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);


            // Nastavení vlastností dataGridView pro lepší vzhled
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersVisible = false;
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Sloupce pro dny v týdnu
            string[] daysOfWeek = { "Pondělí", "Úterý", "Středa", "Čtvrtek", "Pátek", "Sobota", "Neděle" };
            foreach (string day in daysOfWeek)
            {
                dataGridView.Columns.Add(day, day);
            }



            int dayOfWeekStart = (int)startOfMonth.DayOfWeek;
            if (dayOfWeekStart == 0) dayOfWeekStart = 7; // Neděle je 0 v enumu DayOfWeek, ale chceme ji jako 7 pro účely tohoto příkladu

            int currentDay = 1;

            for (int week = 0; week < 5; week++)
            {
                DataGridViewRow row = new DataGridViewRow();

                for (int day = 1; day <= 7; day++)
                {
                    if ((week == 0 && day < dayOfWeekStart) || currentDay > endOfMonth.Day)
                    {
                        row.Cells.Add(new DataGridViewTextBoxCell { Value = "" });
                    }
                    else
                    {
                        var cell = new DataGridViewTextBoxCell { Value = currentDay.ToString() };
                        if (preselectedDays.Contains(currentDay))
                        {
                            cell.Style.BackColor = Color.LightBlue; // Můžete zvolit jinou barvu pro označené dny
                        }
                        row.Cells.Add(cell);
                        currentDay++;
                    }
                }

                dataGridView.Rows.Add(row);
            }

        }


        public List<int> GetSelectedDays()
        {
            List<int> selectedDays = new List<int>();

            foreach (DataGridViewCell cell in dataGridView.SelectedCells)
            {
                if (int.TryParse(cell.Value?.ToString(), out int day))
                {
                    selectedDays.Add(day);
                }
            }

            return selectedDays;
        }




        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }





        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Nastavíme DialogResult formuláře na Cancel a zavřeme ho.
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
