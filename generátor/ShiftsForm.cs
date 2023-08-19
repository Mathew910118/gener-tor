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
using Newtonsoft.Json;

namespace generátor
{
    public partial class ShiftsForm : Form
    {
        private Random random = new Random();
        private const string ShiftsFileName = "shifts.json";
        private DataGridView calendarGridView = new DataGridView();
        private Button btnConfirmSelection = new Button();
        private Button btnCancelSelection = new Button();
        public ShiftsForm()
        {
            InitializeComponent();
            LoadShifts();

            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            listBox1.DrawItem += listBox1_DrawItem;
            listBox1.DoubleClick += listBox1_DoubleClick;
        }

        private void LoadShifts()
        {
            List<Shift> shiftsFromTxt = new List<Shift>();
            List<Shift> shiftsFromJson = new List<Shift>();

            // Načtěte směny z shifts.txt
            if (File.Exists("shifts.txt"))
            {
                string[] lines = File.ReadAllLines("shifts.txt");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 4)
                    {
                        Shift shift = new Shift
                        {
                            Name = parts[0],
                            Length = decimal.Parse(parts[1]),
                            Start = DateTime.Parse(parts[2]),
                            End = DateTime.Parse(parts[3]),
                            Color = Color.Gray
                        };
                        shiftsFromTxt.Add(shift);
                    }
                }
            }

            // Načtěte směny z shifts.json
            if (File.Exists(ShiftsFileName))
            {
                string json = File.ReadAllText(ShiftsFileName);
                shiftsFromJson = JsonConvert.DeserializeObject<List<Shift>>(json);
            }

            // Porovnejte názvy směn a aktualizujte shiftsFromJson
            foreach (Shift shift in shiftsFromTxt)
            {
                if (!shiftsFromJson.Any(s => s.Name == shift.Name))
                {
                    // Přidejte novou směnu
                    shiftsFromJson.Add(shift);
                }
            }

            // Odstraňte směny, které již nejsou v shifts.txt
            shiftsFromJson.RemoveAll(s => !shiftsFromTxt.Any(txtShift => txtShift.Name == s.Name));

            // Aktualizujte listBox1 a uložte změny do shifts.json
            listBox1.Items.Clear();
            listBox1.Items.AddRange(shiftsFromJson.ToArray());
            SaveShifts();
        }



        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            Shift shift = (Shift)listBox1.Items[e.Index];

            // Vykreslete pozadí
            e.DrawBackground();

            // Vykreslete text položky s barvou směny
            using (Brush brush = new SolidBrush(shift.Color))
            {
                e.Graphics.DrawString(shift.ToString(), e.Font, brush, e.Bounds);
            }

            // Vykreslete rámeček kolem položky (pokud je vybrána)
            e.DrawFocusRectangle();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Shift selectedShift = (Shift)listBox1.SelectedItem;
                using (ColorDialog colorDialog = new ColorDialog())
                {
                    if (colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        selectedShift.Color = colorDialog.Color;
                        listBox1.Invalidate(); // Aktualizuje zobrazení listBoxu
                        SaveShifts(); // Uložte směny do JSON souboru
                    }
                }
            }
        }

        private void SaveShifts()
        {
            string json = JsonConvert.SerializeObject(listBox1.Items.Cast<Shift>().ToList());
            File.WriteAllText(ShiftsFileName, json);
        }

    }
}
