using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    [Serializable]
    class Oddzial: IWypozyczalny, ICloneable
    {
        private string nazwaOddzialu;
        private string miasto;
        private int iloscSamochodow;
        private LinkedList<Samochod> samochody;
        private ArrayList listaWypozyczen; //Blad w poleceniu? <>

        public string NazwaOddzialu { get => nazwaOddzialu; set => nazwaOddzialu = value; }
        public string Miasto { get => miasto; set => miasto = value; }
        public int IloscSamochodow { get => iloscSamochodow; set => iloscSamochodow = value; }
        public ArrayList ListaWypozyczen { get => listaWypozyczen; set => listaWypozyczen = value; }
        public LinkedList<Samochod> Samochody { get => samochody; set => samochody = value; }

        public Oddzial()
        {
            iloscSamochodow = 0;
            listaWypozyczen = new ArrayList();
            samochody = new LinkedList<Samochod>();
        }

        public Oddzial(string naz, string city):this()
        {
            nazwaOddzialu = naz;
            miasto = city;
        }

        public void DodajSamochod(Samochod s)
        {
            samochody.AddLast(s);
            iloscSamochodow++;

        }

        public void DodajWypozyczenie(Wypozyczenie w)
        {
            listaWypozyczen.Add(w);
        }

        public void PodajWolneSamochody()
        {
            Console.WriteLine("Oto aktualnie wolne samochody: ");
            foreach(Samochod s in samochody)
            {
                if (s.Wolny) Console.WriteLine(s);
                Console.WriteLine("===============");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Oddzial: " + nazwaOddzialu + " w miescie: " + miasto);
            sb.AppendLine("");
            sb.AppendLine("Samochody w oddziale: ");
            foreach(Samochod s in samochody)
            {
                sb.AppendLine(s.ToString());
                sb.AppendLine("========");
            }
            sb.AppendLine("Wypozyecznia w oddziale: ");
            foreach(Wypozyczenie w in listaWypozyczen)
            {
                sb.AppendLine(w.ToString());
                sb.AppendLine("========");
            }

            return sb.ToString();

        }

        public void Wypozycz(Wypozyczenie w)
        {
            
            if (samochody.Contains(w.WypozyczonySamochod))
            {
                w.WypozyczonySamochod.Wolny = false;
                listaWypozyczen.Add(w);
            }
            else
            {
                Console.WriteLine("Nie mozesz dodac tego wypozyczenia do oddzialu poniewaz oddzial nie posiada takiego samochodu!!!");
            }


        }

        public void Oddaj(Wypozyczenie w)
        {
            if(listaWypozyczen.Contains(w))
            {
                listaWypozyczen.Remove(w);
                w.WypozyczonySamochod.Wolny = true;
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public object Kopiuj()
        {
             Oddzial nowy = new Oddzial();
             nowy.Miasto = this.Miasto;
             nowy.NazwaOddzialu = this.NazwaOddzialu;

             foreach(Samochod s in samochody)
             {
                 Samochod nowySam = (Samochod)s.Clone();
                 nowy.Samochody.AddLast(nowySam);
                 nowy.IloscSamochodow++;
             }

             foreach(Wypozyczenie w in listaWypozyczen)
             {
                 Wypozyczenie noweWyp = (Wypozyczenie)w.Clone();
                 nowy.ListaWypozyczen.Add(noweWyp);
             }

             return nowy; 

           /* BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("deepCopy", FileMode.Create);
            bf.Serialize(fs, this);
            fs.Close();
            FileStream rf = new FileStream("deepCopy", FileMode.Open);
            Oddzial nowyOddzial = (Oddzial)bf.Deserialize(rf);
            return nowyOddzial; */




        }

        public void ZapiszBIN()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("zapis", FileMode.Create);
            bf.Serialize(fs, this);
            fs.Close();        
        }

        public Oddzial OdczytajBIN()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream rf = new FileStream("zapis", FileMode.Open);
            Oddzial odczytanyOddzial = (Oddzial)bf.Deserialize(rf);
            return odczytanyOddzial;
        }
    }
}
