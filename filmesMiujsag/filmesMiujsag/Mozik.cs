using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace filmesMiujsag
{
    internal class Mozik
    {
        public string Nev { get; set; }
        public string Cim { get; set; }
        public string Varos { get; set; }
        public int Ferohely { get; set; }
        public string Nyitvatart { get; set; }

        public Mozik(string nev, string cim, string varos, int ferohely, string nyitvatart)
        {
            Nev = nev;
            Cim = cim;
            Varos = varos;
            Ferohely = ferohely;
            Nyitvatart = nyitvatart;
        }
        public Mozik() { }

        public override string ToString()
        {
            return $"Mozi neve: {Nev}, mozi címe: {Cim}, városa: {Varos}, férőhelyek száma: {Ferohely}, nyitvatartás: {Nyitvatart}";
        }
    }
}
