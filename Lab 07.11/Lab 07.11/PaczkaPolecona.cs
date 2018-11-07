using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07._11
{
    class PaczkaPolecona: Paczka
    {
        static double oplataDodatkowa;

        static PaczkaPolecona()
        {
            oplataDodatkowa = 10;
        }

        public PaczkaPolecona() : base() { }
        public PaczkaPolecona(string n, int r) : base(n, r) { }
        public override double KosztWysylki()
        {
            return base.Rozmiar*OplataZaKg+oplataDodatkowa;
        }

    }
}
