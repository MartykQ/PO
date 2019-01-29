using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgzUlamek
{
    class Program
    {
        static void Main(string[] args)
        {
            Ulamek u1 = new Ulamek(4, 12);
            Console.WriteLine(u1.Licznik.ToString());
            Console.WriteLine(u1.Mianownik.ToString());
            u1.Skroc();
            Console.WriteLine(Ulamek.ZnajdzNWD(4,12).ToString());

            Console.WriteLine(u1.Licznik.ToString());
            Console.WriteLine(u1.Mianownik.ToString());
            Console.ReadKey();

        }
    }
}
