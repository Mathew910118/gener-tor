using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Policista
{
    public string Jmeno { get; set; }
    public string Hodnost { get; set; }
    public List<string> Role { get; set; }

    public Policista(string jmeno, string hodnost, List<string> role)
    {
        this.Jmeno = jmeno;
        this.Hodnost = hodnost;
        this.Role = role;
    }

    public override bool Equals(object obj)
    {
        if (obj is Policista otherPolicista)
        {
            return Jmeno == otherPolicista.Jmeno &&
                   Hodnost == otherPolicista.Hodnost &&
                   Role.SequenceEqual(otherPolicista.Role);
        }
        return false;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + (Jmeno?.GetHashCode() ?? 0);
            hash = hash * 23 + (Hodnost?.GetHashCode() ?? 0);
            hash = hash * 23 + (Role?.GetHashCode() ?? 0);
            return hash;
        }
    }
}
