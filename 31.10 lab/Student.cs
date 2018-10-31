using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Student:Osoba
    {
        private string nrAlbumu;
        private List<Ocena> oceny;



        public Student(string i, string n, string d, string p, Plcie pl, string nr) : base(i, n, d, p, pl)
        {
            NrAlbumu = nr;
            oceny = new List<Ocena>();
        }

        public void DodajOcene(string nazwaP, double wart)
        {
            Ocena nowa = new Ocena(wart, nazwaP);
            oceny.Add(nowa);

        }


        public double ObliczSrednia(string nazwaP)
        {
            double suma = 0;
            int licznik = 0;

            foreach(Ocena o in oceny)
            {
                if (o.Przedmiot.Equals(nazwaP))
                {
                    suma += o.Wartosc;
                    licznik++;
                }

                    
            }
            return suma / licznik;
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            sb.AppendLine("\nStudent: " + nrAlbumu);
            sb.AppendLine("\nOCENY: \n");

            foreach (Ocena o in oceny)
            {
                sb.AppendLine(o.Wartosc.ToString() +" "+ o.Przedmiot.ToString());
            }

            return base.ToString()+sb.ToString();
        }

        public string NrAlbumu { get => nrAlbumu; set => nrAlbumu = value; }
        public List<Ocena> Oceny { get => oceny; set => oceny = value; }
    }
}
