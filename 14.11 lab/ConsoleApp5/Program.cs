using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public enum Plcie {K=0,M=1};

    class Program
    {
        static void Main(string[] args)
        {
         

            
            KierownikZespolu k1 = new KierownikZespolu("Adam", "Kowalski", "1990-07-10", "90070142412", Plcie.M, 5);
            CzlonekZespolu c1 = new CzlonekZespolu("Witold", "Adamski", "1992-10-22", "921066738", Plcie.M, "sekretarz");
            CzlonekZespolu c2 = new CzlonekZespolu("Jan", "Janowski", "1992-03-15", "92031532652", Plcie.M, "programista");
            CzlonekZespolu c3 = new CzlonekZespolu("Jan", "But", "1992-05-16", "92051613915", Plcie.M, "programista");
            CzlonekZespolu c4 = new CzlonekZespolu("Beata", "Nowak", "1993-11-22", "93112225023", Plcie.K, "projektant");
            CzlonekZespolu c5 = new CzlonekZespolu("Annaaaaaaaaaaaaa", "Mysza", "1991-07-22", "91072235964", Plcie.K, "projektant");
            Zespol zes1 = new Zespol("Grupa IT", k1);
            zes1.DodajCzlonka(c1);
            zes1.DodajCzlonka(c2);
            zes1.DodajCzlonka(c3);
            zes1.DodajCzlonka(c4);
            
            CzlonekZespolu c6 = (CzlonekZespolu)c5.Clone();
            c6.Imie = "Marcel";
            DateTime.TryParse("1998-05-08", out c6.dataUrodzenia);
            c6.Plec = Plcie.M;
            Console.WriteLine(c6);
            Console.WriteLine(c5.Plec);

            Zespol z2 = zes1.DeepCopy();
            Zespol z3 = (Zespol)zes1.Clone();
            k1.Imie = "BARANHEHE";
            c1.Nazwisko = "BARAN";
            z2.Nazwa = "NOWKA";
            z2.DodajCzlonka(c5);
            z3.DodajCzlonka(c1);

            z3.SortujPoPesel();
            Console.WriteLine(zes1);
            Console.WriteLine(z2);
            Console.WriteLine(z3);



            Console.ReadKey();
        }
    }
}
