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
            Console.WriteLine(polec+ " oplata za wysylke tego bydlaka to: " + polec.KosztWysylki().ToString());
            Console.ReadKey();

        }
    }
}
