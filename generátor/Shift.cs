using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace generátor
{
    public class Shift
    {
        
        public string Name { get; set; }
        public decimal Length { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Color Color { get; set; }
        public string ColorString { get; set; }


        public override string ToString()
        {
            // Vrátí textovou reprezentaci směny v požadovaném formátu
            return $"{Name};{Length};{Start};{End}";

        }
    }

}

