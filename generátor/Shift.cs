using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generátor
{
    public class Shift
    {
        
        public string Name { get; set; }
        public List<DateTime> Dates { get; set; }
        public decimal Length { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public override string ToString()
        {
            // Vrátí textovou reprezentaci směny v požadovaném formátu
            return $"{Name};{string.Join(",", Dates.Select(d => d.ToString("yyyy-MM-dd")))};{Length};{Start};{End}";
        }
    }

}

