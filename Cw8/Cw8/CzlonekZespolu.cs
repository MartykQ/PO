using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw8

{
    [Serializable]
    public class CzlonekZespolu:Osoba,ICloneable,IComparable
    {
        private string funkcja;

        public string Funkcja
        {
            get { return funkcja; }
            set { funkcja = value; }
        }
        public CzlonekZespolu() { }

        public CzlonekZespolu(string i, string n, string d, string p, Plcie plec, string f)
            : base(i, n, d, p, plec)
        {
            this.funkcja = f;
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.funkcja;
        }

        public object Clone()
        {
            //return new CzlonekZespolu(Imie,Nazwisko,DataUr.ToShortDateString(),Pesel,Plec,funkcja);
            return this.MemberwiseClone();
        }

        public int CompareTo(Object o)
        {
            if (o != null)
            {
                CzlonekZespolu c = (CzlonekZespolu)o;
                int cmp = this.Nazwisko.CompareTo(c.Nazwisko);
                if (cmp != 0)
                    return cmp;
                else
                    return this.Imie.CompareTo(c.Imie);
            }
            else
                return 1;
        }
    }
}
