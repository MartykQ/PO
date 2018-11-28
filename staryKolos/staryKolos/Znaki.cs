using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staryKolos
{
    class Znaki
    {
        private ArrayList kolekcjaZnakow;


        public ArrayList KolekcjaZnakow { get => kolekcjaZnakow; set => kolekcjaZnakow = value; }

        public Znaki()
        {
            kolekcjaZnakow = new ArrayList();

        }

        public Znaki(int liczba, char znak): this()
        {
            for(int i = 0; i < liczba; i++)
            {
                kolekcjaZnakow.Add(znak);
            }
        }

        public Znaki(string napis): this()
        {
            char[] tablChar = napis.ToCharArray();
            foreach(char c in tablChar)
            {
                kolekcjaZnakow.Add(c);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(char c in kolekcjaZnakow)
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        public virtual void DodajZnak(char znak) //ogarnac
        {
            kolekcjaZnakow.Add(znak);
        }

        public bool CzyJest(char znak)
        {
            if (kolekcjaZnakow.Contains(znak)) return true;
            else return false;

        }

        public int IleJest(char znak)
        {
            int suma = 0;
            foreach(char c in kolekcjaZnakow)
            {
                if (c == znak) suma++;
            }
            return suma;
        }

        public void Zastap(char znak, char nowy)
        {
            for(int i = 0; i< kolekcjaZnakow.Count; i++)
            {
                if ((char)kolekcjaZnakow[i] == znak) kolekcjaZnakow[i] = nowy;
            }           
        }





    }


}
