using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    class Program
    {
        static void Main(string[] args)
        {
            Samochod fiacik = new Samochod("Fiat", "Polo", "KBR11", 5, true);
            Samochod opel = new Samochod("Opel", "Corsa", "KBR11", 5, true);

            Wypozyczenie nowa = new Wypozyczenie("franek", opel, "1998-05-09", "2010-12-12");          
            Wypozyczenie kradziez = new Wypozyczenie("kamil", fiacik, "1998-05-09", "2010-12-12");     
            
            Oddzial war = new Oddzial("kaktus", "krakow");
            war.DodajSamochod(opel);

            Oddzial oddzialKrakow = new Oddzial("Pierwszy", "Krakow");
            Oddzial oddzialKatowice = (Oddzial)oddzialKrakow.Kopiuj();  //dziala
            oddzialKrakow.DodajSamochod(opel);
            Console.WriteLine(oddzialKrakow);
            Console.WriteLine("===============");
            Console.WriteLine(oddzialKatowice);

            Console.ReadKey();


        }
    }
}
