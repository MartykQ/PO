using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp5
{
    [Serializable]
    public class Zespol:ICloneable, IEquatable<Zespol>, IZapisywalna
    {
        private int liczbaCzlonkow;
        private string nazwa;
        private KierownikZespolu kierownik;
        private List<CzlonekZespolu> czlonkowie;

        public int LiczbaCzlonkow { get => liczbaCzlonkow; set => liczbaCzlonkow = value; }
        public string Nazwa { get => nazwa; set => nazwa = value; }
        public KierownikZespolu Kierownik { get => kierownik; set => kierownik = value; }
        public List<CzlonekZespolu> Czlonkowie { get => czlonkowie; set => czlonkowie = value; }

        public Zespol()
        {
            liczbaCzlonkow = 0;
            nazwa = null;
            kierownik = null;
            Czlonkowie = new List<CzlonekZespolu>();
        }

        public Zespol(string n, KierownikZespolu k) : this() 
            {
            nazwa = n;
            kierownik = k;            
            }

        public void DodajCzlonka(CzlonekZespolu c)
        {
            Czlonkowie.Add(c);
            liczbaCzlonkow++;
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            sb.AppendLine("Zespol: " + nazwa);
            sb.AppendLine("Kiero: " + kierownik + "\nCZLONKOWIE: \n");

            foreach(CzlonekZespolu c in Czlonkowie)
            {
                sb.AppendLine(c.ToString());
            }

            return sb.ToString();

        }

        public bool JestCzlonkiem(string p)
        {
            foreach(CzlonekZespolu c in Czlonkowie)
            {
                if (c.Pesel.Equals(p)) return true;


            }
            return false;
        }

        public bool JestCzlonkiem(string i, string n)
        {
            foreach (CzlonekZespolu c in Czlonkowie)
            {
                if ( c.Imie.Equals(i) && c.Nazwisko.Equals(n)) return true;


            }
            return false;
        }

        public bool JestCzlonkiem(CzlonekZespolu c)
        {
            foreach (CzlonekZespolu cz in Czlonkowie)
            {
                if (cz.Equals(c)) //komparator
                {
                    return true;
                }                              
            }return false;
            
        }

        public void UsunCzlonka(string p)
        {
            foreach (CzlonekZespolu c in Czlonkowie)
            {
                if (c.Pesel.Equals(p))
                {
                    Czlonkowie.Remove(c);
                    liczbaCzlonkow--;
                    return;
                }


            }
            Console.WriteLine("Nie ma takiego PESEL w zespole");

        }

        public void UsunCzlonka(string i, string n)
        {
            foreach (CzlonekZespolu c in Czlonkowie)
            {
                if ( c.Imie.Equals(i) && c.Nazwisko.Equals(n))
                {
                    Czlonkowie.Remove(c);
                    liczbaCzlonkow--;
                    return;
                }


            }
            Console.WriteLine("Nie ma takiego imienia i nazwiska w zespole");

        }

        public void UsunWszystkich()
        {
            liczbaCzlonkow = 0;
            Czlonkowie.Clear();

        }

       public List<CzlonekZespolu> WyszukajFunkcje(string f)
        {
            List<CzlonekZespolu> nowaLista = new List<CzlonekZespolu>();
            nowaLista = Czlonkowie.FindAll(c => c.Funkcja.Equals(f));
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
            foreach (CzlonekZespolu cz in Czlonkowie)
            {
                CzlonekZespolu c = (CzlonekZespolu)cz.Clone();
                kopia.DodajCzlonka(c);

            }
            return kopia;

        }

        public void Sortuj()
        {
            Czlonkowie.Sort();
        }

        public void SortujPoPesel()
        {

            Czlonkowie.Sort(new PESELComparator());

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

        public void ZapiszBIN(string nazwa)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(nazwa, FileMode.Create);
            bf.Serialize(fs, this);
            fs.Close();
        }

        public object OdczytajBIN(string nazwa)
        {
            Zespol zespolOdczytany;
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(nazwa, FileMode.Open);
                zespolOdczytany = (Zespol)bf.Deserialize(fs);
                fs.Close();
                return zespolOdczytany;
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Nie znaleziono pliku");
                return null;
            }
        }

        public static void ZapiszXML(string nazwa, Zespol z)
        {
            XmlSerializer sr = new XmlSerializer(typeof(Zespol));
            StreamWriter sw = new StreamWriter(nazwa);
            sr.Serialize(sw, z);
            sw.Close();
        }

        public static Zespol OdczytajXML(string nazwa)
        {
            Zespol odczytanyZespol;
            try
            {

                XmlSerializer sr = new XmlSerializer(typeof(Zespol));
                TextReader tr = new StreamReader(nazwa);
                odczytanyZespol = (Zespol)sr.Deserialize(tr);
                tr.Close();
                return odczytanyZespol;
            }
            catch(FieldAccessException)
            {
                Console.WriteLine("Nie znaleziono pliku");
            }
            return null;
        }

        public static void ZapiszJSON(string nazwa, Zespol z)
        {
            DataContractJsonSerializer jsonSr = new DataContractJsonSerializer(typeof(Zespol));
            using (var fsstream = File.Create(nazwa))
            {
                jsonSr.WriteObject(fsstream, z);
            }
        }

        public static Zespol OdczytajJSON(string nazwa)
        {
            try
            {
                FileStream fsstream = new FileStream(nazwa, FileMode.Open);
                DataContractJsonSerializer jsonSr = new DataContractJsonSerializer(typeof(Zespol));
                fsstream.Position = 0;
                Zespol z = (Zespol)jsonSr.ReadObject(fsstream);
                fsstream.Close();
                return z;



            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Nie znaleziono pliku");

            }return null;
        }

    }


    public class PESELComparator : IComparer<CzlonekZespolu>
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
