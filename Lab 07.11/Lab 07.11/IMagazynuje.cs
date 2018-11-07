using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07._11
{
    interface IMagazynuje
    {
        void Umiesc(Paczka t);
        Paczka Pobierz();
        void Wyczysc();
        int PodajIlosc();
        Paczka PodajBiezacy();
    }
}
