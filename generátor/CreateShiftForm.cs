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
    public partial class CreateShiftForm : Form
    {
        private ManageShiftsForm _manageShiftForm;

        public CreateShiftForm(ManageShiftsForm manageShiftForm)
        {
            InitializeComponent();
            _manageShiftForm = manageShiftForm;

            // Nastavení výchozích hodnot
            txtShiftName.Text = "Default Shift Name";
            monthCalendar1.SelectionStart = DateTime.Now;  // dnešní datum
            monthCalendar1.SelectionEnd = DateTime.Now;    // dnešní datum
            numericUpDownShiftLength.Value = 8;  // výchozí délka směny
            dateTimePickerStart.Value = DateTime.Now;
            dateTimePickerEnd.Value = DateTime.Now.AddHours(8); // +8 hodin od aktuálního času
            _manageShiftForm = manageShiftForm;
        }

        private void btnCreateShift_Click(object sender, EventArgs e)
        {
            string shiftName = txtShiftName.Text;
            List<DateTime> selectedDates = new List<DateTime>();
            for (DateTime date = monthCalendar1.SelectionStart; date <= monthCalendar1.SelectionEnd; date = date.AddDays(1))
            {
                selectedDates.Add(date);
            }
            decimal shiftLength = numericUpDownShiftLength.Value;
            DateTime startTime = dateTimePickerStart.Value;
            DateTime endTime = dateTimePickerEnd.Value;

            // Vytvoření nové směny
            Shift newShift = new Shift
            {
                Name = shiftName,
                Dates = selectedDates,
                Length = shiftLength,
                Start = startTime,
                End = endTime
            };

            // Přidání nové směny do seznamu v ManageShiftForm
            _manageShiftForm.AddShiftToList(newShift);
            _manageShiftForm.SaveShiftToFile(ManageShiftsForm.ShiftsFilePath, newShift.ToString());

            this.Close();
        }

        public void SetShiftData(Shift shift)
        {
            txtShiftName.Text = shift.Name;
            monthCalendar1.SelectionStart = shift.Dates.First();
            monthCalendar1.SelectionEnd = shift.Dates.Last();
            numericUpDownShiftLength.Value = shift.Length;
            dateTimePickerStart.Value = shift.Start;
            dateTimePickerEnd.Value = shift.End;
        }

    }
}

