using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class CzlonekZespolu:Osoba, ICloneable, IComparable
    {


        private string funkcja;

        public CzlonekZespolu(string i, string n, string d, string p, Plcie pl, string f):base(i, n, d, p, pl)
        {
            Funkcja = f;
        }

        public string Funkcja { get => funkcja; set => funkcja = value; }

        public object Clone()
        {
            return this.MemberwiseClone(); //plytka kopia
        }

        public int CompareTo(object obj)
        {
            if (obj != null)
            {
                CzlonekZespolu c = (CzlonekZespolu)obj;
                int cmp = this.Nazwisko.CompareTo(c.Nazwisko);
                if(cmp!=0)
                {
                    return cmp;
                }
                else
                {
                    return this.Imie.CompareTo(c.Imie);
                }

            }
            throw new Exception("Obj = null");
        }

        public override string ToString()
        {
            return base.ToString()+ " "+ Funkcja;
        }
    }
}
