using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staryKolos
{
    class Program
    {
        static void Main(string[] args)
        {
            Znaki pierwsze = new Znaki("siemaa testy");
            Console.WriteLine(pierwsze);
            Console.WriteLine(pierwsze.IleJest('a'));
            pierwsze.Zastap('a', 'b');
            Console.WriteLine(pierwsze);
            Litery literki = new Litery();
            literki.DodajZnak('/');
            Console.ReadKey();

        }
    }
}
