using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw8

{
    public enum Plcie { K = 0, M = 1 };
    class Program
    {
        static void Main(string[] args)
        {
            CzlonekZespolu c1 = new CzlonekZespolu("Beata", "Nowak", "1993/11/22", "93112225023", Plcie.K, "projektant");
            CzlonekZespolu c2 = new CzlonekZespolu("Jan", "Janowski", "1992-03-15", "92031532652", Plcie.M, "programista");
            CzlonekZespolu c3 = new CzlonekZespolu("Witold", "Adamski", "1992-10-22", "92102266738", Plcie.M, "sekretarz");
            CzlonekZespolu c4 = new CzlonekZespolu("Anna", "Mysza", "1991/07/22", "91072235964", Plcie.K, "projektant");
            CzlonekZespolu c5 = new CzlonekZespolu("Jan", "But", "1992/05/16", "92051613915", Plcie.M, "programista");
            KierownikZespolu k1 = new KierownikZespolu("Adam", "Kowalski", "1990-07-01", "90070142412", Plcie.M, 5);

            CzlonekZespolu c6 = (CzlonekZespolu) c2.Clone();
            Zespol z1 = new Zespol("Zespół IT",k1);
            /*KierownikZespolu k2 = (KierownikZespolu)k1.Clone();
            k2.Nazwisko = "Zet";
            k2.Doswiadczenie = 7;*/
            //z1.Nazwa = "Zespół IT";
            //z1.Kierownik = k1;
            z1.DodajCzlonka(c1);
            z1.DodajCzlonka(c2);
            z1.DodajCzlonka(c3);
            z1.DodajCzlonka(c4);
            z1.DodajCzlonka(c5);

            Console.Write(z1);
            Console.WriteLine();
            Console.WriteLine(" === Zapis do pliku XML ==== ");
            Zespol.ZapiszXML("zespol2.xml",z1);
            Console.WriteLine(" === Zapisano !!! === ");
            Console.WriteLine("=== Odczyt z pliku XML ====");
            Zespol z2 = new Zespol();
            z2 = (Zespol)Zespol.OdczytajXML("zespol2.xml");
            Console.WriteLine(" ===========  Odczytano  =========");
            Console.Write(z2);
            Console.WriteLine();

            /*Console.Write(z1);
            Console.WriteLine();
            Console.WriteLine(" === Zapis do pliku binarnego ==== ");
            z1.ZapiszBIN("zespol1.bin");
            Console.WriteLine(" === Zapisano !!! === ");
            Console.WriteLine("=== Odczyt z pliku binarnego ====");
            Zespol z2 = new Zespol();
            z2 = (Zespol)z2.OdczytajBIN("zespol1.bin");
            Console.WriteLine(" ===========  Odczytano  =========");
            Console.Write(z2);
            Console.WriteLine();*/
            /*
            Console.Write(z1);
            Console.WriteLine();
            Console.WriteLine(" === Zapis do pliku JSON ==== ");
            Zespol.ZapiszJSON("zespol3.json", z1);
            Console.WriteLine(" === Zapisano !!! === ");
            Console.WriteLine("=== Odczyt z pliku JSON ====");
            Zespol z2 = new Zespol();
            z2 = (Zespol)Zespol.OdczytajJSON("zespol3.json");
            Console.WriteLine(" ===========  Odczytano  =========");
            Console.Write(z2);
            Console.WriteLine();

            //Console.WriteLine(" ==== kopiowanie członka zespołu ==== ");

            /*c6.Imie = "Ala";
            DateTime date;
            DateTime.TryParseExact("1988-12-05", new[] { "yyyy-MM-dd", "yyyy/MM/dd", "MM/dd/yy", "dd-MMM-yy" }, 
                null, DateTimeStyles.None, out date);
            c6.DataUr = date;
            c6.Pesel = "88120520551";
            c6.Plec = Plcie.K;*/
            /*Console.WriteLine(c2);
            Console.WriteLine(c6);*/
            /*Console.WriteLine(" ==== kopiowanie zespołu ==== ");
            Zespol z2 = (Zespol)z1.Clone();
            z2.Nazwa = "Drugi Zespół";
            z2.Kierownik = k2;
            z2.Kierownik.Imie = "Robert";
            
            z2.DodajCzlonka(c6);
            Zespol z3 = (Zespol)z1.DeepCopy();
            z3.Nazwa = "Trzeci Zespół";
            z3.Kierownik = k2;
            z3.Kierownik.Imie = "Robert";
            z3.DodajCzlonka(c6);
            Console.Write(z1);
            Console.WriteLine();
            Console.Write(z2);
            Console.WriteLine();
            Console.Write(z3);*/
            //z2.DodajCzlonka(c6);
            //Console.Write(z1);
            //Console.WriteLine("Liczba czlonków {0}", z1.Liczbaczlonkow);
            //Console.WriteLine();

            //Console.Write(z2);
            //Console.WriteLine("Liczba czlonków {0}", z2.Liczbaczlonkow);
            /*Console.WriteLine(" ==== sortowanie po nazwisku ==== ");
            Console.WriteLine();
            z2.Sortuj();
            Console.Write(z2);
            Console.WriteLine();
            Console.WriteLine(" ==== sortowanie po peselu ==== ");
            Console.WriteLine();
            z2.SortujPoPesel();
            Console.Write(z2);*/
            //Console.WriteLine(c6.ToString() +" "+ z2.JestCzlonkiem(c6));
            Console.ReadKey();

        }
    }
}
