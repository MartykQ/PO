using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace powtorka

{
    [Serializable]
    public class PojemnikNaLancuchy : ICloneable, IComparable, IEquatable<PojemnikNaLancuchy>
    {
        private string nazwaLancucha;
        private ArrayList kolekcja;


        public string NazwaLancucha { get => nazwaLancucha; set => nazwaLancucha = value; }
        public ArrayList Kolekcja { get => kolekcja; set => kolekcja = value; }

        public PojemnikNaLancuchy()
        {
            this.nazwaLancucha = "";
            kolekcja = new ArrayList();

        }

        public PojemnikNaLancuchy(string n) : this()
        {
            this.nazwaLancucha = n;

        }

        public PojemnikNaLancuchy(string naz, string sr) : this(naz)
        {
            this.DodajString(sr);
        }

        public void DodajString(string s)
        {
            kolekcja.Add(s);
        }

        public void WstawIndeks(int i, string s)
        {
            try
            {
                kolekcja.Insert(i, s);
            }
            catch (IndexOutOfRangeException) //ktory
            {
                Console.WriteLine("Zly indeks!");
            }
        }

        public void Usun(int i)
        {
            try
            {
                kolekcja.RemoveAt(i);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Zly indeks");
            }

        }

        public void Zamien(string stary, string nowy)
        {

            kolekcja[kolekcja.IndexOf(stary)] = nowy;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in kolekcja)
            {
                sb.Append(s);
                sb.Append(" ");
            }
            return sb.ToString();
        }

        public object Clone() //mialo byc binarnie...
        {
            /*
            XmlSerializer xs = new XmlSerializer(typeof(PojemnikNaLancuchy));
            StreamWriter sw = new StreamWriter("PojemnikNaLancuchy.xml");
            xs.Serialize(sw, this);
            sw.Close();

            XmlSerializer dsr = new XmlSerializer(typeof(PojemnikNaLancuchy));
            TextReader tr = new StreamReader("PojemnikNaLancuchy.xml");
            PojemnikNaLancuchy nowyPojemnik;
            nowyPojemnik = (PojemnikNaLancuchy)dsr.Deserialize(tr);
            tr.Close();
            return nowyPojemnik;
            */

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("deepCopy", FileMode.Create);
            bf.Serialize(fs, this);
            fs.Close();
            FileStream rf = new FileStream("deepCopy", FileMode.Open);
            PojemnikNaLancuchy nowyPojemnik = (PojemnikNaLancuchy)bf.Deserialize(rf);
            return nowyPojemnik;
        }

        public object CloneSimple() //zwykly DeppClone
        {
            PojemnikNaLancuchy nowy = new PojemnikNaLancuchy();
            nowy.NazwaLancucha = this.NazwaLancucha;
            foreach(string s in this.kolekcja)
            {
                nowy.kolekcja.Add(s);
            }
            return nowy;
        }

        public int CompareTo(object obj)
        {
            int comparer;
            PojemnikNaLancuchy nowy = (PojemnikNaLancuchy)obj;
            for (int i = 0; i < Math.Min(this.kolekcja.Count, nowy.Kolekcja.Count); i++)
            {
                string s1 = (string)this.kolekcja[i];
                string s2 = (string)nowy.kolekcja[i];
                comparer = s1.CompareTo(s2);
                if (comparer != 0) return comparer;

            }
            return 0;

        }

        public bool Equals(PojemnikNaLancuchy other)
        {
            if (other.NazwaLancucha.Equals(this.NazwaLancucha) && other.Kolekcja.Count == this.Kolekcja.Count)
            {
                for(int i = 0; i<this.Kolekcja.Count; i++)
                {
                    if (!other.Kolekcja[i].Equals(this.kolekcja[i])) return false;
                }
                return true;
            }
            else return false;
        }

        public void ZapiszXML(string nazwa)
        {
            XmlSerializer sr = new XmlSerializer(typeof(PojemnikNaLancuchy));
            StreamWriter sw = new StreamWriter(nazwa);
            sr.Serialize(sw, this);
            sw.Close();

        }

        public static object WczytajXML(string nazwa)
        {
            XmlSerializer sr = new XmlSerializer(typeof(PojemnikNaLancuchy));
            TextReader tr = new StreamReader(nazwa);
            return (object)sr.Deserialize(tr);
        }
    }
}
