using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace generátor
{
    public partial class ManageShiftsForm : Form
    {
        private Shift _currentlyEditingShift;
        private List<Policista> allPolicists;
        private Dictionary<string, bool> checkedState = new Dictionary<string, bool>();
        public const string ShiftsFilePath = "shifts.txt";


        public ManageShiftsForm(List<Policista> policists)
        {
            InitializeComponent();
            allPolicists = policists;
            UpdatePolicistList();
            LoadShifts();
        }

        private void UpdatePolicistList(string filter = "")
        {
            clbPolicists.Items.Clear();

            IEnumerable<Policista> filteredPolicists;
            if (string.IsNullOrWhiteSpace(filter))
            {
                filteredPolicists = allPolicists;
            }
            else
            {
                filteredPolicists = allPolicists.Where(p => p.Jmeno.ToLower().Contains(filter.ToLower()));
            }

            foreach (var policista in filteredPolicists)
            {
                clbPolicists.Items.Add(policista.Jmeno, checkedState.ContainsKey(policista.Jmeno) && checkedState[policista.Jmeno]);
            }
        }

        private void UpdateShiftList()
        {
            if (_currentlyEditingShift != null)
            {
                lstShifts.Items.Remove(_currentlyEditingShift.ToString()); // Odebereme původní směnu
                _currentlyEditingShift = null;
            }

            System.IO.File.WriteAllLines(ShiftsFilePath, lstShifts.Items.Cast<string>());
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            UpdatePolicistList(txtSearch.Text);
        }

        // This method should be triggered when a Policist item is checked or unchecked
        private void clbPolicists_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var policistName = clbPolicists.Items[e.Index].ToString();
            var isChecked = e.NewValue == CheckState.Checked;

            if (checkedState.ContainsKey(policistName))
            {
                checkedState[policistName] = isChecked;
            }
            else
            {
                checkedState.Add(policistName, isChecked);
            }
        }

        private void LoadShifts()
        {
            lstShifts.Items.Clear();
            var shifts = LoadShiftsFromFile(ShiftsFilePath);
            foreach (var shift in shifts)
            {
                lstShifts.Items.Add(shift);
            }
        }

        public void SaveShiftToFile(string fileName, string shiftData)
        {
            try
            {
                File.AppendAllText(fileName, shiftData + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nastala chyba při ukládání směny: {ex.Message}");
            }
        }

        private List<string> LoadShiftsFromFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                    return File.ReadAllLines(fileName).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Nastala chyba při načítání směn: {ex.Message}");
            }
            return new List<string>();
        }

        private void btnCreateShift_Click(object sender, EventArgs e)
        {
            CreateShiftForm createShiftForm = new CreateShiftForm(this);
            createShiftForm.ShowDialog();


        }

        private void btnDeleteShift_Click(object sender, EventArgs e)
        {
            // Získání vybrané směny
            string selectedShift = (string)lstShifts.SelectedItem;

            // Ověření, zda je směna vybrána
            if (string.IsNullOrEmpty(selectedShift))
            {
                MessageBox.Show("Vyberte směnu k odstranění.");
                return;
            }

            // Potvrzení smazání
            var result = MessageBox.Show($"Opravdu chcete smazat směnu '{selectedShift}'?", "Potvrzení smazání", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Smazání směny ze seznamu
                lstShifts.Items.Remove(selectedShift);

                // Aktualizace souboru shifts.txt
                System.IO.File.WriteAllLines("shifts.txt", lstShifts.Items.Cast<string>());
            }
        }

        public void AddShiftToList(Shift shift)
        {
            lstShifts.Items.Add(shift.ToString()); // Přidáváme kompletní textovou reprezentaci směny do ListBoxu
        }

        private void btnEditShift_Click(object sender, EventArgs e)
        {
            Shift selectedShift = GetSelectedShift();

            if (selectedShift == null)
            {
                MessageBox.Show("Vyberte směnu k úpravě.");
                return;
            }

            _currentlyEditingShift = selectedShift; // Uložíme si směnu před editací

            CreateShiftForm editShiftForm = new CreateShiftForm(this);
            editShiftForm.SetShiftData(selectedShift);
            editShiftForm.ShowDialog();

            UpdateShiftList();
        }


        private Shift GetSelectedShift()
        {
            string selectedShiftString = (string)lstShifts.SelectedItem;

            if (string.IsNullOrEmpty(selectedShiftString))
                return null;

            string[] parts = selectedShiftString.Split(';');

            if (parts.Length < 4)  // Abychom se ujistili, že máme dostatek částí po rozdělení řetězce.
                return null;

            Shift shift = new Shift
            {
                Name = parts[0],
                Length = decimal.Parse(parts[1]),
                Start = DateTime.Parse(parts[2]),
                End = DateTime.Parse(parts[3])
            };

            return shift;
        }

        public bool DoesShiftNameExist(string shiftName)
        {
            return lstShifts.Items.Cast<string>().Any(item => item.StartsWith(shiftName + ";", StringComparison.OrdinalIgnoreCase));
        }



    }
}
