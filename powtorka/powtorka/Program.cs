using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace powtorka
{
    class Program
    {
        static void Main(string[] args)
        {

            PojemnikNaLancuchy poj1 = new PojemnikNaLancuchy("nazwa", "pierwszy napis");
            poj1.DodajString("drugi string");
            poj1.WstawIndeks(0, "dodanyjakopierw");
            poj1.Zamien("dodanyjakopierw", "zamieniony");
            

            Console.WriteLine(poj1);
            Console.ReadKey();
        }
    }
}
