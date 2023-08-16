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
            lstShifts.Items.Clear(); // Předpokládáme, že máte ListBox s názvem lstShifts pro zobrazení seznamu směn
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
            lstShifts.Items.Add(shift.Name); // Zde přidáváme název směny do ListBoxu
                                             // Můžete také přidat další logiku, např. ukládání do databáze nebo kolekce v paměti, atd.
        }

        private void btnEditShift_Click(object sender, EventArgs e)
        {
            Shift selectedShift = GetSelectedShift();

            if (selectedShift == null)
            {
                MessageBox.Show("Vyberte směnu k úpravě.");
                return;
            }

            CreateShiftForm editShiftForm = new CreateShiftForm(this);

            // Nastavíme hodnoty formuláře na základě vybrané směny
            editShiftForm.SetShiftData(selectedShift);

            editShiftForm.ShowDialog();

            // Aktualizace souboru shifts.txt
            System.IO.File.WriteAllLines(ShiftsFilePath, lstShifts.Items.Cast<string>());
        }


        private Shift GetSelectedShift()
        {
            string selectedShiftString = (string)lstShifts.SelectedItem;

            if (string.IsNullOrEmpty(selectedShiftString))
                return null;

            string[] parts = selectedShiftString.Split(';');

            Shift shift = new Shift
            {
                Name = parts[0],
                Dates = parts[1].Split(',').Select(date => DateTime.Parse(date)).ToList(),
                Length = decimal.Parse(parts[2]),
                Start = DateTime.Parse(parts[3]),
                End = DateTime.Parse(parts[4])
            };

            return shift;
        }

    }
}
