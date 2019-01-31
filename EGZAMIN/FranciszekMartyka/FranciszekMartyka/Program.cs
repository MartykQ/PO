using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranciszekMartyka
{
    class Program
    {
        static void Main(string[] args) //GUI ustawione jako startowe
        {
            Wiadomosc w1 = new Wiadomosc("urzad@gmina.pl", "Odpowiedz na pismo z dnia 1.10.2018");
            Wiadomosc w2 = new Wiadomosc("dziekanat@tytul.pl", "Zawiadomienie o terminie praktyk");
            Wiadomosc w3 = new Wiadomosc("promocje@grupex.com", "Promocja na telefony samsung");
            Wiadomosc w4 = new Wiadomosc("promocje@grupex.com", "Promocja na pobyt w spa");

            Console.WriteLine(w1.Tytul);

            FolderWiadomosci f1 = new FolderWiadomosci();

            f1.DodajWiadomosc(w1);
            f1.DodajWiadomosc(w2);
            f1.DodajWiadomosc(w3);
            f1.DodajWiadomosc(w4);

            List<Wiadomosc> listaWiadomosciGrupex = f1.Wyszukaj("promocje@grupex.com");
            
            foreach(Wiadomosc w in listaWiadomosciGrupex)
            {
                Console.WriteLine(w);
            }


            Console.WriteLine("=============TESTY KLONOWANIA==================");
            FolderWiadomosci sklonowany = (FolderWiadomosci)f1.Clone();

            w1.Tresc += "TESTUJE CZY DZIALA KLONOWANIE";

            foreach(Wiadomosc w in sklonowany.KolejkaWiadomosci)
            {
                Console.WriteLine(w);
            }

            foreach (Wiadomosc w in f1.KolejkaWiadomosci)
            {
                Console.WriteLine(w);
            }




            Console.ReadKey();


        }
    }
}
