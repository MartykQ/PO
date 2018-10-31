using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Wykladowca:Osoba
    {
        private TytulW tytul;

        public Wykladowca(string i, string n, string d, string p, Plcie pl, TytulW tit) : base(i, n, d, p, pl)
        {
            tytul = tit;

        }

        public override string ToString()
        {
            return base.ToString()+"\nTYTUL NAUKOWY: "+tytul;
        }

        public TytulW Tytul { get => tytul; set => tytul = value; }
    }
}
