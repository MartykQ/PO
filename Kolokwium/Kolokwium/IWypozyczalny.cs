using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    interface IWypozyczalny
    {
        void Wypozycz(Wypozyczenie w);
        void Oddaj(Wypozyczenie w);
    }
}
