using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_07._11
{
    class Program
    {
        static void Main(string[] args)
        {
            Paczka przesylka = new Paczka("Marcin", 2);
            Paczka przesylka2 = new Paczka("Podstrup", 16);
            Paczka przesylka3 = new Paczka("Franciszek", 9);
            PaczkaPolecona polec = new PaczkaPolecona("nadawca", 16);
            PaczkaPolecona polec2 = new PaczkaPolecona("roemk", 2);

            Console.WriteLine(polec+ " oplata za wysylke to: " + polec.KosztWysylki().ToString());
            
            MagazynLIFO barak = new MagazynLIFO("Barak z paczkami");
            barak.Umiesc(przesylka);
            barak.Umiesc(przesylka2);
            barak.Umiesc(przesylka3);
            barak.Umiesc(polec);
            barak.Umiesc(polec2);
            Console.WriteLine("-------------------\n\n\n------------------\n\n");
            Console.WriteLine(barak);
            Console.WriteLine("-------------------\n\n\n------------------\n\n");
            barak.Pobierz();
            Console.WriteLine(barak);
            Console.WriteLine("-------------------\n\n\n------------------\n\n");
            Console.ReadKey();
        }
    }
}
