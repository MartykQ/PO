using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07._11
{
    interface IMagazynujeTablice
    {
        void Wyczysc();
        int PodajIlosc();
        void UmiescNaPoczatku(Paczka pIN);
        void UmiescPrzed(Paczka pB, Paczka pIN);
        void UmiescPo(Paczka pA, Paczka pIN);
        void UmiescOstatni(Paczka pIN);
        void UsunPierwszeWystapienie(Paczka pIN);
        void UsunPierwszy();
        void UsunOstatni();

    }
}
