using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class KierownikZespolu:Osoba, ICloneable
    {
        int Doswiadczenie { get; set; }
        public KierownikZespolu(string i, string n, string d, string p, Plcie pl, int ex) : base(i, n, d, p, pl)
        {
            Doswiadczenie = ex;


        }

        public override string ToString()
        {
            return base.ToString() + " Doswiadczenie: " + Doswiadczenie;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
