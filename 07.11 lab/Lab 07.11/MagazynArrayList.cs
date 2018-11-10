using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab_07._11
{
    class MagazynArrayList
    {
        string nazwa;
        int liczbaPaczek;
        ArrayList listaPaczek;

        public string Nazwa { get => nazwa; set => nazwa = value; }
        public int LiczbaPaczek { get => liczbaPaczek; set => liczbaPaczek = value; }
        public ArrayList ListaPaczek { get => listaPaczek; set => listaPaczek = value; }

        public MagazynArrayList()
        {
            listaPaczek = new ArrayList();
            liczbaPaczek = 0;
        }

        public MagazynArrayList(string n):this()
        {
            nazwa = n;
        }

        public void DodajPaczkeAt(int poz, Paczka p)
        {
            listaPaczek.Insert(poz, p);
            liczbaPaczek++;
        }

        public void DodajNaKoniec(Paczka p)
        {
            listaPaczek.Add(p);
            liczbaPaczek++;
        }

        public int IlePaczek()
        {
            return listaPaczek.Count;

        }

        public void UsunNa(int i)
        {
            try
            {
                listaPaczek.RemoveAt(i);
            }
            catch(ArgumentOutOfRangeException)
            {
                Console.WriteLine("Zly indeks!");
            }
        }

        public void UsunPaczke(Paczka p)
        {
            listaPaczek.Remove(p);
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("PACZKI W MAGAZYNIE kolejkowym");
            foreach (Paczka p in listaPaczek)
            {
                sb.AppendLine(p.NumerPaczki + " NADAWCA: " + p.Nadawca);
            }
            return sb.ToString();
        }
    }
}
