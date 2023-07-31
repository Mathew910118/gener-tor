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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSeznamPolicistu formSeznamPolicistu = new FormSeznamPolicistu();
            formSeznamPolicistu.ShowDialog(); // Použijte Show() místo ShowDialog(), pokud chcete okno nemodální.

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormGenerovaniSmen formGenerovaniSmen = new FormGenerovaniSmen();
            formGenerovaniSmen.ShowDialog(); // Použijte Show() místo ShowDialog(), pokud chcete okno nemodální.
        }
    }
}
