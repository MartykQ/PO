using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07._11
{
    class MagazynLIFO:IMagazynuje
    {
        string nazwa;
        int iloscPaczek;
        Stack<Paczka> listaPaczek;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int IloscPaczek { get => iloscPaczek; set => iloscPaczek = value; }
        internal Stack<Paczka> ListaPaczek { get => listaPaczek; set => listaPaczek = value; }

        public MagazynLIFO()
        {
            nazwa = "";
            iloscPaczek = 0;
            listaPaczek = new Stack<Paczka>();
        }

        public MagazynLIFO(Stack<Paczka> stos):this()
        {
            listaPaczek = stos;
        }
        //konstruktor parametryczny ktroemu podajemy stos jako parametr
        public MagazynLIFO(string n):this()
        {
            nazwa = n;
        }

        public Paczka Pobierz()
        {
            iloscPaczek--;
            return listaPaczek.Pop();
        }

        public Paczka PodajBiezacy()
        {
            return listaPaczek.Peek();
        }

        public int PodajIlosc()
        {
            return listaPaczek.Count();
            //return iloscPaczek;
        }

        public void Umiesc(Paczka t)
        {
            listaPaczek.Push(t);
            iloscPaczek++;

        }

        public void Wyczysc()
        {
            iloscPaczek = 0;
            listaPaczek.Clear();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("PACZKI W MAGAZYNIE");
            foreach(Paczka p in listaPaczek)
            {
                sb.AppendLine(p.NumerPaczki + " NADAWCA: " + p.Nadawca);
            }
            return sb.ToString();
        }
    }
}
