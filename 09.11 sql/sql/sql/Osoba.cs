using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace sql

{
    [Serializable]
    [XmlInclude(typeof(CzlonekZespolu))]
    [XmlInclude(typeof(KierownikZespolu))]
    public class Osoba:IEquatable<Osoba>
    {
        private string imie;
        public string Nazwisko { get; set; }
        private DateTime dataUrodzenia;
        [XmlAttribute]
        private string PESEL;
        private Plcie plec;
        public string Imie
        {
            get { return imie; }
            set { imie = value; }
        }

        public DateTime DataUr { get { return dataUrodzenia; } set { dataUrodzenia = value; } }
        public Plcie Plec { get { return plec; } set { plec = value; } }
        public string Pesel
        {
            get { return PESEL; }
            set
            {
                try
                {
                    if (!checkPESEL(value))
                    {
                        throw new wronPESELExcepition();
                    }
                    PESEL = value;

                }
                catch (wronPESELExcepition e)
                {
                    Console.WriteLine(e.Message);
                    PESEL = new String('0', 11);
                }
            }
        }
        public bool checkPESEL(string p)
        {
            if (p.Length != 11) return false;
            //using System.Text.RegularExpressions;
            //Regex rgx = new Regex(@"(\d){11}");
            //if (!rgx.IsMatch(p)) return false;
            if (p[9] % 2 != (int)Plec) return false;
            return true;
        }
        public Osoba()
        {
            imie = null;
            Nazwisko = null;
            dataUrodzenia = DateTime.MinValue;
            PESEL = "00000000000";
        }
        public Osoba(string imie, string nazwisko)
        {
            this.imie = imie;
            this.Nazwisko = nazwisko;
        }
        public Osoba(string imie, string nazwisko, string d, string pesel, Plcie p)
        {
            this.imie = imie;
            Nazwisko = nazwisko;
            DateTime date;
            DateTime.TryParseExact(d, new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, null, DateTimeStyles.None, out date);
            this.dataUrodzenia = date;
            this.plec = p;
            if (!checkPESEL(pesel))
            {
                throw new wronPESELExcepition();
            }
            this.PESEL = pesel;
        }

        public int Wiek()
        {
            return (DateTime.Now.Year - DataUr.Year);
        }

        public override string ToString()
        {
            return this.imie + " " + this.Nazwisko + " " + dataUrodzenia.ToShortDateString() + " " + this.PESEL + " " + this.plec;
        }

        public bool Equals(Osoba other)
        {
            if (other == null)
                return false;
            if (this.Pesel == other.Pesel)
                return true;
            else
                return false;
        }
    }
}
