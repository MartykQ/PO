using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranciszekMartyka
{
    public class Wiadomosc: ICloneable
    {
        private string email;
        private string tytul;
        private string tresc;

        public string Email { get => email; set => email = value; }
        public string Tytul { get => tytul; set => tytul = value; }
        public string Tresc { get => tresc; set => tresc = value; }

        public Wiadomosc(string mail, string tekst)
        {
            email = mail;
            tresc = tekst;

            string[] pom = tekst.Split(); //tablica stringow

            int iterator = 0; //pomocnicza do wyjscia z petli

            foreach(string p in pom)
            {
                if(p.Length>=3)
                {
                    tytul += p + " ";
                    iterator++;
                }
                if (iterator >= 2) break;
            }
        }

        public override string ToString()
        {
            return this.email + ": " + this.tresc;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
