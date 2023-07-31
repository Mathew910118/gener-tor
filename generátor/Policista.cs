using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generátor
{
    public class Policista
    {
        public string Jmeno { get; set; }
        public string Hodnost { get; set; }
        public List<string> Role { get; set; }

        public Policista(string jmeno, string hodnost, List<string> role)
        {
            Jmeno = jmeno;
            Hodnost = hodnost;
            Role = role;
        }
    }

}
