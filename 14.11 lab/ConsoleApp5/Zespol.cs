using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Zespol:ICloneable, IEquatable<Zespol>
    {
        private int liczbaCzlonkow;
        private string nazwa;
        private KierownikZespolu kierownik;
        private List<CzlonekZespolu> czlonkowie;

        public int LiczbaCzlonkow { get => liczbaCzlonkow; set => liczbaCzlonkow = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }
        internal KierownikZespolu Kierownik { get => kierownik; set => kierownik = value; }

        public Zespol()
        {
            liczbaCzlonkow = 0;
            nazwa = null;
            kierownik = null;
            czlonkowie = new List<CzlonekZespolu>();
        }

        public Zespol(string n, KierownikZespolu k) : this() 
            {
            nazwa = n;
            kierownik = k;            
            }

        public void DodajCzlonka(CzlonekZespolu c)
        {
            czlonkowie.Add(c);
            liczbaCzlonkow++;
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            sb.AppendLine("Zespol: " + nazwa);
            sb.AppendLine("Kiero: " + kierownik + "\nCZLONKOWIE: \n");

            foreach(CzlonekZespolu c in czlonkowie)
            {
                sb.AppendLine(c.ToString());
            }

            return sb.ToString();

        }

        public bool JestCzlonkiem(string p)
        {
            foreach(CzlonekZespolu c in czlonkowie)
            {
                if (c.Pesel.Equals(p)) return true;


            }
            return false;
        }

        public bool JestCzlonkiem(string i, string n)
        {
            foreach (CzlonekZespolu c in czlonkowie)
            {
                if ( c.Imie.Equals(i) && c.Nazwisko.Equals(n)) return true;


            }
            return false;
        }

        public bool JestCzlonkiem(CzlonekZespolu c)
        {
            foreach (CzlonekZespolu cz in czlonkowie)
            {
                if (cz.Equals(c)) //komparator
                {
                    return true;
                }                              
            }return false;
            
        }

        public void UsunCzlonka(string p)
        {
            foreach (CzlonekZespolu c in czlonkowie)
            {
                if (c.Pesel.Equals(p))
                {
                    czlonkowie.Remove(c);
                    liczbaCzlonkow--;
                    return;
                }


            }
            Console.WriteLine("Nie ma takiego PESEL w zespole");

        }

        public void UsunCzlonka(string i, string n)
        {
            foreach (CzlonekZespolu c in czlonkowie)
            {
                if ( c.Imie.Equals(i) && c.Nazwisko.Equals(n))
                {
                    czlonkowie.Remove(c);
                    liczbaCzlonkow--;
                    return;
                }


            }
            Console.WriteLine("Nie ma takiego imienia i nazwiska w zespole");

        }

        public void UsunWszystkich()
        {
            liczbaCzlonkow = 0;
            czlonkowie.Clear();

        }

       public List<CzlonekZespolu> WyszukajFunkcje(string f)
        {
            List<CzlonekZespolu> nowaLista = new List<CzlonekZespolu>();
            nowaLista = czlonkowie.FindAll(c => c.Funkcja.Equals(f));
            return nowaLista;
        }

        public object Clone() //plytka kopia
        {
            return this.MemberwiseClone();
        }

        public Zespol DeepCopy()
        {
            Zespol kopia = new Zespol();
            //kopia.nazwa = this.nazwa;
            kopia.kierownik = (KierownikZespolu)this.kierownik.Clone();
            foreach (CzlonekZespolu cz in czlonkowie)
            {
                CzlonekZespolu c = (CzlonekZespolu)cz.Clone();
                kopia.DodajCzlonka(c);

            }
            return kopia;

        }

        public void Sortuj()
        {
            czlonkowie.Sort();
        }

        public void SortujPoPesel()
        {

            czlonkowie.Sort(new PESELComparator());

        }

        public bool Equals(Zespol other)
        {
            if (other.Nazwa.Equals(this.Nazwa)
                && other.Kierownik.Equals(this.Kierownik)
                && other.liczbaCzlonkow == this.liczbaCzlonkow)
            {
                return true;
            }
            else return false;
        }
    }


    class PESELComparator : IComparer<CzlonekZespolu>
    {
        public int Compare(CzlonekZespolu a, CzlonekZespolu b)
        {
            if(a != null && b!=null)
            {
                return a.Pesel.CompareTo(b.Pesel);
            }
            else 
            return 0;
        }




    }
}
