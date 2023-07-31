using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace generátor
{
    public partial class FormSeznamPolicistu : Form
    {
        private List<Policista> seznamPolicistu;

        public FormSeznamPolicistu()
        {
            InitializeComponent();

            seznamPolicistu = new List<Policista>();
        }

        // Metoda pro uložení seznamu policistů do souboru
        private void NacistDataZeSouboru()
        {
            // Ověření, zda soubor existuje
            if (File.Exists("seznam_policistu.txt"))
            {
                // Pokud soubor existuje, načteme data
                using (StreamReader sr = new StreamReader("seznam_policistu.txt"))
                {
                    // Vyčistíme aktuální seznam policistů
                    seznamPolicistu.Clear();

                    // Postupně načteme řádky ze souboru
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Rozdělíme řádek podle oddělovače (čárka)
                        string[] data = line.Split(',');

                        // Rozdělíme řetězec s rolí podle středníku
                        string jmeno = data[0];
                        string hodnost = data[1];
                        List<string> roleList = data[2].Split(';').Select(r => r.Trim()).ToList();

                        Policista novyPolicista = new Policista(jmeno, hodnost, roleList);
                        seznamPolicistu.Add(novyPolicista);
                    }
                }

                // Aktualizujeme zobrazení v DataGridView
                ZobrazitDataVDataGridView();
            }
            else
            {
                // Pokud soubor neexistuje, vytvoříme prázdný seznam policistů
                seznamPolicistu = new List<Policista>();
            }
        }

        private void UlozitDataDoSouboru()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Textové soubory (*.txt)|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (Policista policista in seznamPolicistu)
                        {
                            string roles = string.Join(";", policista.Role.ToArray());
                            sw.WriteLine($"{policista.Jmeno},{policista.Hodnost},{roles}");
                        }
                    }
                }
            }

            MessageBox.Show("Data byla úspěšně uložena do souboru.");
        }






        private void ZobrazitDataVDataGridView()
        {
            // Vymazání stávajících řádků v DataGridView
            dataGridView1.Rows.Clear();

            // Přidání nových řádků na základě seznamu policistů
            foreach (Policista policista in seznamPolicistu)
            {
                string jmeno = policista.Jmeno;
                string hodnost = policista.Hodnost;
                string role = string.Join(", ", policista.Role);
                dataGridView1.Rows.Add(jmeno, hodnost, role);
            }
        }

        private void btnUlozitZmeny_Click(object sender, EventArgs e)
        {
            // Načíst všechny existující data z DataGridView a uložit je zpět do seznamu seznamPolicistu
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue; // Ignorovat nový prázdný řádek

                string jmeno = row.Cells["Jmeno"].Value?.ToString();
                string hodnost = row.Cells["Hodnost"].Value?.ToString();
                string role = row.Cells["Role"].Value?.ToString();

                if (!string.IsNullOrEmpty(jmeno) && !string.IsNullOrEmpty(hodnost) && !string.IsNullOrEmpty(role))
                {
                    List<string> roleList = role.Split(',').Select(r => r.Trim()).ToList();
                    Policista policista = new Policista(jmeno, hodnost, roleList);

                    if (!seznamPolicistu.Contains(policista))
                    {
                        seznamPolicistu.Add(policista);
                    }
                }
            }

            // Aktualizujte zobrazení v DataGridView
            ZobrazitDataVDataGridView();

            // Uložit data do souboru
            UlozitDataDoSouboru();
        }





        private void btnNacistData_Click(object sender, EventArgs e)
        {
            // Vyprázdnit existující seznam policistů
            seznamPolicistu.Clear();

            // Načíst data ze souboru a přidat je do seznamu
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Textové soubory (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] data = line.Split(',');
                            if (data.Length >= 3)
                            {
                                string jmeno = data[0];
                                string hodnost = data[1];
                                List<string> roleList = data[2].Split(';').ToList();
                                Policista policista = new Policista(jmeno, hodnost, roleList);
                                seznamPolicistu.Add(policista);
                            }
                        }
                    }
                }
            }

            // Aktualizovat zobrazení v DataGridView
            ZobrazitDataVDataGridView();
        }




        private void PridatPolicistu_Click(object sender, EventArgs e)
        {
            // Získání hodnot z DataGridView pro nového policistu
            string jmeno = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Jmeno"].Value?.ToString();
            string hodnost = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Hodnost"].Value?.ToString();
            string role = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Role"].Value?.ToString();

            // Pokud jsou všechna pole vyplněná, přidáme nového policistu do seznamu
            if (!string.IsNullOrEmpty(jmeno) && !string.IsNullOrEmpty(hodnost) && !string.IsNullOrEmpty(role))
            {
                List<string> roleList = role.Split(',').Select(r => r.Trim()).ToList();
                Policista novyPolicista = new Policista(jmeno, hodnost, roleList);
                seznamPolicistu.Add(novyPolicista);

                // Aktualizujte zobrazení v DataGridView
                ZobrazitDataVDataGridView();
            }
            else
            {
                MessageBox.Show("Vyplňte všechna pole pro nového policistu.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
