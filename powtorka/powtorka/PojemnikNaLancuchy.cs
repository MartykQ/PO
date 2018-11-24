using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powtorka
{
    class PojemnikNaLancuchy
    {
        private string nazwaLancucha;
        private ArrayList kolekcja;


        public string NazwaLancucha { get => nazwaLancucha; set => nazwaLancucha = value; }
        public ArrayList Kolekcja { get => kolekcja; set => kolekcja = value; }

        public PojemnikNaLancuchy()
        {
            this.nazwaLancucha = "";
            kolekcja = new ArrayList();

        }

        public PojemnikNaLancuchy(string n) : this()
        {
            this.nazwaLancucha = n;

        }

        public PojemnikNaLancuchy(string naz, string sr): this(naz)
        {
            this.DodajString(sr);
        }

        public void DodajString(string s)
        {
            kolekcja.Add(s);
        }

        public void WstawIndeks(int i, string s)
        {
            try
            {
                kolekcja.Insert(i, s);
            }
            catch(IndexOutOfRangeException) //ktory
            {
                Console.WriteLine("Zly indeks!");
            }
        }

        public void Usun(int i)
        {
            try
            {
                kolekcja.RemoveAt(i);
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Zly indeks");
            }

        }

        public void Zamien(string stary, string nowy)
        {
            if (kolekcja.Contains(stary))
            {
                this.WstawIndeks(kolekcja.IndexOf(stary), nowy);
                this.Usun(kolekcja.IndexOf(stary) + 1);
                return;
            }
            else
            {
                Console.WriteLine("Nie ma takiego napisu!!");
            }


        }
            


            

        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(string s in kolekcja)
            {
                sb.Append(s);
                sb.Append(" ");
            }
            return sb.ToString();
        }



    }
}
