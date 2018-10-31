using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Grupa
    {
        private string nazwaPrzedmiotu;
        private string numerGrupy;
        private int liczbaStudentow;
        private Wykladowca wykladowca;
        private List<Student> studenci;


        public Grupa(string np, string nrgr, Wykladowca w)
        {
            nazwaPrzedmiotu = np;
            numerGrupy = nrgr;
            wykladowca = w;
            liczbaStudentow = 0;
            studenci = new List<Student>();

        }

        public void DodajStudenta(Student s)
        {
            studenci.Add(s);
            liczbaStudentow++;
        }

        public bool JestStudentem(string nr)
        {
            foreach(Student s in studenci)
            {
                if(s.NrAlbumu.Equals(nr))
                {
                    return true;
                }
            }

            return false;
        }

        public bool JestStudentem(string i, string n)
        {
            foreach (Student s in studenci)
            {
                if (s.Imie.Equals(i)&&s.Nazwisko.Equals(n))
                {
                    return true;
                }
            }
            return false;
        }

        public void UsunStudenta(string nr)
        {
            studenci.RemoveAll(ce => ce.NrAlbumu.Equals(nr));
            liczbaStudentow--;

        }

        public void UsunStudenta(string i, string n)
        {
            studenci.RemoveAll(ce => ce.Imie.Equals(i) && ce.Nazwisko.Equals(n));
            liczbaStudentow--;
        }

        public void UsunWszystkich()
        {
            liczbaStudentow = 0;
            studenci.Clear();
        }

        public void DodajOcene(double o, Student s)
        {
            if (studenci.Contains(s))
            {
                s.DodajOcene(nazwaPrzedmiotu, o);
            }

            else throw new Exception();


        }


        public double WyznaczSredniaOcen(Student s)
        {
            if (studenci.Contains(s))
            {

                return s.ObliczSrednia(nazwaPrzedmiotu);


            }
            else throw new Exception("Takiego studenta nie ma w tej grupie");

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("GRUPA: " + numerGrupy);
            sb.AppendLine("PRZEDMIOT: " + nazwaPrzedmiotu);
            sb.AppendLine("PROWADZACY: " + wykladowca.Imie + " " + wykladowca.Nazwisko);
            sb.AppendLine("Studenci w grupie: ");
            foreach(Student s in studenci)
            {
                sb.AppendLine(s.Nazwisko +" "+ s.Imie);
            }

            return sb.ToString();
        }

        public string NazwaPrzedmiotu { get => nazwaPrzedmiotu; set => nazwaPrzedmiotu = value; }
        public string NumerGrupy { get => numerGrupy; set => numerGrupy = value; }
        public int LiczbaStudentow { get => liczbaStudentow; set => liczbaStudentow = value; }
        internal Wykladowca Wykladowca { get => wykladowca; set => wykladowca = value; }
        internal List<Student> Studenci { get => studenci; set => studenci = value; }
    }
}
