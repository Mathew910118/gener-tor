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
            numericUpDownShiftLength.Value = 8;  // výchozí délka směny
            dateTimePickerStart.Value = DateTime.Now;
            dateTimePickerEnd.Value = DateTime.Now.AddHours(8); // +8 hodin od aktuálního času
            _manageShiftForm = manageShiftForm;
        }

        private void btnCreateShift_Click(object sender, EventArgs e)
        {
            string shiftName = txtShiftName.Text;

            // Kontrola existence názvu směny
            if (_manageShiftForm.DoesShiftNameExist(shiftName))
            {
                MessageBox.Show("Směna s tímto názvem již existuje. Zvolte jiný název.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal shiftLength = numericUpDownShiftLength.Value;
            DateTime startTime = dateTimePickerStart.Value;
            DateTime endTime = dateTimePickerEnd.Value;

            // Vytvoření nové směny
            Shift newShift = new Shift
            {
                Name = shiftName,
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
            numericUpDownShiftLength.Value = shift.Length;
            dateTimePickerStart.Value = shift.Start;
            dateTimePickerEnd.Value = shift.End;
        }
    }
}
