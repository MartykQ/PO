using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cw8
{
    [Serializable]
    [XmlRoot("Zespol")]
    public class Zespol:ICloneable,IZapisywalna
    {
        private int liczbaczlonkow;
        private string nazwa;
        private KierownikZespolu kierownik;
        private List<CzlonekZespolu> czlonkowie;
        [NonSerialized]
        [XmlIgnore]
        public string plik = "zespol.txt";
        public int Liczbaczlonkow { get { return liczbaczlonkow; } set { liczbaczlonkow = value; } }
        public string Nazwa { get { return nazwa; } set { nazwa = value; } }
        public KierownikZespolu Kierownik { get { return kierownik; } set { kierownik = value; } }
        public List<CzlonekZespolu> Czlonkowie { get { return czlonkowie; } set { czlonkowie = value; } }

        public Zespol()
        {
            liczbaczlonkow = 0;
            nazwa = null;
            kierownik = null;
            Czlonkowie = new List<CzlonekZespolu>();
        }

        public Zespol(string n, KierownikZespolu k):this()
        {
            nazwa = n;
            kierownik = k;
        }

        public void DodajCzlonka(CzlonekZespolu c)
        {
            Czlonkowie.Add(c);
            liczbaczlonkow++;
        }

        public override string ToString()
        {
            System.Text.StringBuilder sb = new StringBuilder();
            sb.AppendLine("Zespół :" + nazwa);
            sb.AppendLine("kierownik: " + kierownik+ "\n członkowie:");
            foreach(CzlonekZespolu c in Czlonkowie)
            {
                sb.AppendLine(c.ToString());
            }
            return sb.ToString();
        }
        public bool JestCzlonkiem(string p)
        {
            for(int i = 0; i < Czlonkowie.Count; i++)
            {
                if (Czlonkowie.ElementAt(i).Pesel.Equals(p)) return true;
                //if (czlonkowie.ElementAt(i).Pesel==p) return true;
            }
            return false;
        }
        public bool JestCzlonkiem(CzlonekZespolu c)
        {
            foreach (CzlonekZespolu cz in Czlonkowie)
            {
                if (cz.Equals(c))
                    return true;
            }
            return false;
        }
        public void UsunCzlonka(string p)
        {
            if (JestCzlonkiem(p))
            {
                Czlonkowie.Remove(Czlonkowie.Find(c => c.Pesel.Equals(p)));
                liczbaczlonkow--;
            }
        }
        public List<CzlonekZespolu> WyszukajFunkcje(string f)
        {
            List<CzlonekZespolu> nowaLista = new List<CzlonekZespolu>();
            /*foreach(CzlonekZespolu c in czlonkowie)
            {
                if (c.Funkcja.Equals(f)) nowaLista.Add(c);
            }*/
            nowaLista = Czlonkowie.FindAll(c => c.Funkcja.Equals(f));
            return nowaLista;
        }

        public object Clone()
        {
            return MemberwiseClone();  // Uwaga : nie kopiujemy czlonkow
        }
        public Zespol DeepCopy()
        {
            Zespol kopia=new Zespol();
            kopia.kierownik = (KierownikZespolu)kierownik.Clone();
            //kopia.czlonkowie = new List<CzlonekZespolu>(czlonkowie.Select(x => (CzlonekZespolu)x.Clone()));
            var new1 = new List<CzlonekZespolu>(Czlonkowie.Select(x => ((CzlonekZespolu) x.Clone())));
            kopia.Czlonkowie = new1;
            kopia.liczbaczlonkow = Czlonkowie.Count();
            //kopia.liczbaCzlonkow = 0;
            /*foreach(CzlonekZespolu c in this.czlonkowie){
               CzlonekZespolu cc = (CzlonekZespolu)c.Clone();
               kopia.DodajCzlonka(cc);
            }*/

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

        public void ZapiszBIN(string nazwaPliku)
        {
            BinaryFormatter bf =new BinaryFormatter();
            FileStream fs = new FileStream(nazwaPliku, FileMode.Create);
            bf.Serialize(fs, this);
            fs.Close();
        }

        public object OdczytajBIN(string nazwaPliku)
        {
            Zespol zespolOdczytany;
            
            try
            {
                FileStream fs = new FileStream(nazwaPliku, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                zespolOdczytany = (Zespol)bf.Deserialize(fs);
                fs.Close();
                return zespolOdczytany;
            }
            catch (FileNotFoundException)
            {
                SystemSounds.Exclamation.Play();
                Console.WriteLine("Plik {0} nie istnieje!!!", nazwaPliku);
            }
            return null;
        }

        public static void ZapiszXML(string nazwaPliku, Zespol z)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Zespol));
            StreamWriter sw = new StreamWriter(nazwaPliku);
            serializer.Serialize(sw, z);
            sw.Close();
        }
        public static Object OdczytajXML(string nazwaPliku)
        {
            Zespol zespolOdczytany;
            try
            {
                TextReader tr = new StreamReader(nazwaPliku);
                XmlSerializer serializer = new XmlSerializer(typeof(Zespol));
                zespolOdczytany = (Zespol)serializer.Deserialize(tr);
                tr.Close();
                return zespolOdczytany;
            }catch(FileNotFoundException)
            {
                SystemSounds.Exclamation.Play();
                Console.WriteLine("Plik {0} nie istnieje!!!", nazwaPliku);
            }
            return null;
        }
        public static void ZapiszJSON(string nazwaPliku, Zespol z)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Zespol));
            //StreamWriter writer = new StreamWriter(nPliku);
            using (var fstream = File.Create(nazwaPliku))
            {
                jsonSerializer.WriteObject(fstream, z);
            }
        }
        public static Zespol OdczytajJSON(string nazwaPliku)
        {
            // Deserializacja JSON
            try
            {
                FileStream fstream = new FileStream(nazwaPliku, FileMode.Open);
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Zespol));
                fstream.Position = 0;
                Zespol z = (Zespol)jsonSerializer.ReadObject(fstream);
                fstream.Close();
                return z;
            }
            catch (FileNotFoundException)
            {
                SystemSounds.Exclamation.Play();
                Console.WriteLine("Plik {0} nie istnieje!!!", nazwaPliku);
            }
            return null;
        }


    }
    [Serializable]
    class PESELComparator : IComparer<CzlonekZespolu>
    {
        public int Compare(CzlonekZespolu a, CzlonekZespolu b)
        {
            if (a != null && b != null)
                return a.Pesel.CompareTo(b.Pesel);
            else
                return 0;
        }
    }

}
