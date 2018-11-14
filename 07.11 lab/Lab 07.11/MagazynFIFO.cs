using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07._11
{
    class MagazynFIFO : IMagazynuje
    {
        string nazwa;
        int iloscPaczek;
        Queue<Paczka> kolejkaPaczek;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int IloscPaczek { get => iloscPaczek; set => iloscPaczek = value; }
        internal Queue<Paczka> KolejkaPaczek { get => kolejkaPaczek; set => kolejkaPaczek = value; }

        public MagazynFIFO()
        {
            kolejkaPaczek = new Queue<Paczka>();
            iloscPaczek = 0;
            nazwa = "";
        }
        public MagazynFIFO(Queue<Paczka> kolejka):this()
        {
            kolejkaPaczek = kolejka;
        }
        public MagazynFIFO(string n):this()
        {
            nazwa = n;
        }

        public Paczka Pobierz()
        {
            iloscPaczek--;
            return kolejkaPaczek.Dequeue();
            
        }

        public Paczka PodajBiezacy()
        {
            return kolejkaPaczek.Peek();
        }

        public int PodajIlosc()
        {
            return kolejkaPaczek.Count();
        }

        public void Umiesc(Paczka t)
        {
            kolejkaPaczek.Enqueue(t);
        }

        public void Wyczysc()
        {
            kolejkaPaczek.Clear();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("PACZKI W MAGAZYNIE kolejkowym");
            foreach (Paczka p in kolejkaPaczek)
            {
                sb.AppendLine(p.NumerPaczki + " NADAWCA: " + p.Nadawca);
            }
            return sb.ToString();
        }
    }
}
