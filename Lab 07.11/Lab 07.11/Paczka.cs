using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07._11
{
    class Paczka
    {

        string nadawca;
        int rozmiar;
        string numerPaczki;
        static int liczbaPaczek;
        static double oplataZaKg;

        public string Nadawca { get => nadawca; set => nadawca = value; }
        public int Rozmiar { get => rozmiar; set => rozmiar = value; }
        public string NumerPaczki { get => numerPaczki; set => numerPaczki = LiczbaPaczek+"/2018"; }
        public static int LiczbaPaczek { get => liczbaPaczek; set => liczbaPaczek = value; }
        public static double OplataZaKg { get => oplataZaKg; set => oplataZaKg = value; }
    }
}
