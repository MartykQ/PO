using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    abstract class Osoba
    {
        private string imie;
        public string Nazwisko { get; set; }
        public DateTime dataUrodzenia;
        private string PESEL;
        private Plcie plec;

        public string Imie
        {
            get
            { return imie; }
            set
            { imie = value; }
        }

        public string Pesel
        {
            get
            {
                return PESEL;
            }

            set
            {

                if (value.Length == 11 && value.ToString().Substring(0, 6).Equals(this.DataPesel())) 
                {
                    PESEL = value;
                }
                else throw new PeselException("wtf");
            }


        }

        public Plcie Plec
        {
            get
            {
                return plec;
            }
            set
            {
                plec = value;
            }
        }

        public Osoba()
        {
            imie = "";
            Nazwisko = "";
            dataUrodzenia = DateTime.MinValue;
            PESEL = "00000000000";
        }

        public Osoba(string i, string n) : this()
        {
            Imie = i;
            Nazwisko = n;
        }

        public Osoba(string i, string n, string d, string p, Plcie pl):this(i, n)
        {
            DateTime data;
            bool r = DateTime.TryParseExact(d, new[] { "yyyy/MM/dd", "MM/dd/yy", "yyyy-MM-dd", "dd-MMM-yy" }, null, DateTimeStyles.None, out data);
            if (r) dataUrodzenia = data; //nie ma znaczenia czy DataUrodzenia czy dataUrodzenia
            Pesel = p;
            Plec = pl;
            
        }
        
        public int Wiek()
        {
            return DateTime.Now.Year - dataUrodzenia.Year;
        }
        
        public override string ToString()
        {

            string s = "";
            s += Imie + " " + Nazwisko + " " + dataUrodzenia.ToShortDateString() + " " + Pesel;
            return s;
        }

        public string DataPesel()
        {
            string s = dataUrodzenia.ToShortDateString().Substring(8, 2)+
            dataUrodzenia.ToShortDateString().Substring(3, 2) +
            dataUrodzenia.ToShortDateString().Substring(0, 2);
           
            return s;
        }
    }
}
