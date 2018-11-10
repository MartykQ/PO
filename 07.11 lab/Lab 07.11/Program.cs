using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab_07._11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CO CHCESZ WYBRAC? ;): ");
            Console.WriteLine("1. MagazynLIFO - stos - last in first out");
            int wybor;
            int.TryParse(Console.ReadLine(),out wybor);

            switch(wybor)
            {
                case 1:
                    Stos();
                    break;

                case 2:
                    Kolejka();
                    break;

                case 3:
                    ListaWiazana();
                    break;
                case 4:
                    ListaTablicowa();
                    break;


                default:
                    break;

            }
        }

        static void Stos()
        {
            Paczka przesylka = new Paczka("Marcin", 2);
            Paczka przesylka2 = new Paczka("Podstrup", 16);
            Paczka przesylka3 = new Paczka("Franciszek", 9);
            PaczkaPolecona polec = new PaczkaPolecona("nadawca", 16);
            PaczkaPolecona polec2 = new PaczkaPolecona("roemk", 2);

            Console.WriteLine(polec + " oplata za wysylke to: " + polec.KosztWysylki().ToString());

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

        static void Kolejka()
        {
            Paczka przesylka = new Paczka("Marcin", 2);
            Paczka przesylka2 = new Paczka("Podstrup", 16);
            Paczka przesylka3 = new Paczka("Franciszek", 9);
            PaczkaPolecona polec = new PaczkaPolecona("nadawca", 16);
            PaczkaPolecona polec2 = new PaczkaPolecona("roemk", 2);

            MagazynFIFO barakKolejkowy = new MagazynFIFO("barak Kolejkowy");
            barakKolejkowy.Umiesc(przesylka);
            barakKolejkowy.Umiesc(przesylka2);
            barakKolejkowy.Umiesc(przesylka3);
            barakKolejkowy.Umiesc(polec);
            barakKolejkowy.Umiesc(polec2);

            Console.WriteLine(barakKolejkowy);
            Console.WriteLine("PO pobraniu paczki: ");
            barakKolejkowy.Pobierz();
            Console.WriteLine(barakKolejkowy);
            Console.WriteLine("Po umieszczeniu paczki: \n");
            barakKolejkowy.Umiesc(przesylka3);
            Console.WriteLine(barakKolejkowy);
            Console.ReadKey();


        }

        static void ListaWiazana()
        {
            
            

            Paczka przesylka = new Paczka("Marcin", 2);
            Paczka przesylka2 = new Paczka("Podstrup", 16);
            Paczka przesylka3 = new Paczka("Franciszek", 9);
            PaczkaPolecona polec = new PaczkaPolecona("nadawca", 16);
            PaczkaPolecona polec2 = new PaczkaPolecona("roemk", 2);

            MagazynLinkedList nowyMagazyn = new MagazynLinkedList();
            nowyMagazyn.UmiescNaPoczatku(przesylka);
            nowyMagazyn.UmiescNaPoczatku(przesylka2);
            nowyMagazyn.UmiescPrzed(przesylka, przesylka3);
            
            Console.WriteLine(nowyMagazyn);

            nowyMagazyn.UmiescOstatni(polec2);
            nowyMagazyn.UmiescNaPoczatku(polec);
            Console.WriteLine("\n\n\n----------\n"+nowyMagazyn);
            Console.ReadKey();

        }

        static void ListaTablicowa()
        {

            Paczka przesylka = new Paczka("Marcin", 2);
            Paczka przesylka2 = new Paczka("Podstrup", 16);
            Paczka przesylka3 = new Paczka("Franciszek", 9);
            PaczkaPolecona polec = new PaczkaPolecona("nadawca", 16);
            PaczkaPolecona polec2 = new PaczkaPolecona("roemk", 2);


            MagazynArrayList magazynA = new MagazynArrayList();
            magazynA.DodajNaKoniec(przesylka);
            magazynA.DodajNaKoniec(przesylka2);
            magazynA.DodajNaKoniec(polec);
            magazynA.DodajNaKoniec(polec2);
            magazynA.DodajNaKoniec(przesylka3);

            magazynA.UsunNa(5);
            Console.WriteLine(magazynA);
            Console.ReadKey();





        }
    }
}
