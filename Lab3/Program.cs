using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions; //REGEX

namespace ConsoleApp3
{

    class Wpis
    {
        public string imie;
        public string numer;

        public void ustawImie(string imie)
        {
            this.imie = imie;
        }

        public void ustawNumer(string numer)
        {
            this.numer = numer;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("1. zad1 OdwrocTekst \n" +
                "2. zad2 OdwrocZdanie");
            Console.WriteLine("Podaj nummer:");
            int wybor = int.Parse(Console.ReadLine());

            switch (wybor)
            {
                case 1:
                    Console.WriteLine("Podaj napis ktory chcesz odwrocic: ");
                    string tekst = Console.ReadLine();
                    Console.WriteLine(OdwrocTekst(tekst));
                    Console.ReadKey();
                    break;

                case 2:
                    Console.WriteLine("Podaj zdanie ktore chcesz odwrocic: ");
                    tekst = Console.ReadLine();
                    Console.WriteLine(OdwrocZdanie(tekst));
                    Console.ReadKey();
                    break;

                case 3:
                    Console.WriteLine("Podaj date urodzin:");
                    Console.WriteLine("Rok:");
                    int rok = int.Parse(Console.ReadLine());
                    Console.WriteLine("miesiac:");
                    int miesiac = int.Parse(Console.ReadLine());
                    Console.WriteLine("dzien:");
                    int dzien = int.Parse(Console.ReadLine());
                    Console.WriteLine(Dni(rok, miesiac, dzien) + ": tyle dni przezyles do dzisiaj");
                    Console.ReadKey();
                    break;

                case 4:
                    Wyswietl2();
                    break;

                case 5:
                    Filtr();
                    break;

                case 6:
                    Ksiazka();
                    break;

                case 7:
                    Totek();
                    break;

                default:

                    Console.WriteLine("Zly numer!");
                    break;

                
            }

        }

        //zad 1
        static string OdwrocTekst(string napis)
        {
            string odwrocony;
            char[] tablica = new char[napis.Length];
            tablica = napis.ToCharArray();          
            odwrocony = string.Join("", tablica.Reverse());            
            return odwrocony;
      
        }

        //zad2
        static string OdwrocZdanie(string zdanie)
        {
            string odwrocone = "";
            string[] tablica = zdanie.Split().ToArray();               
            return string.Join(" ", tablica.Reverse());
        }

        //zad3
        static int Dni(int rok, int miesiac, int dzien)
        {
            DateTime dataur = new DateTime(rok, miesiac, dzien);
            DateTime teraz = DateTime.Now;
            int roznica = (int)((teraz.Date - dataur.Date).TotalDays);
            return roznica;

        }



        //zad4      
        static void Wyswietl2()
        {
            string text = System.IO.File.ReadAllText("plik.txt");
            Console.WindowHeight = 40;
            Console.WindowWidth = 130;
            Console.Clear();
            text = text.Replace("\n", " ");                
            int count = 1; //zliczanie linijek 

            for(int i=0; i<text.Length;i++) //i = indeks
            {
                if (i % 120 == 0)
                {
                    Console.Write("\n");
                    count = count + 1;
                    if(count % 35 ==0)
                    {

                        while (true) 
                        {
                            Console.WriteLine("\n\nWcisnij spacje aby przjesc dalej!");
                            ConsoleKeyInfo info = Console.ReadKey();        // tutaj link: https://www.dotnetperls.com/console-readkey                
                            if (info.KeyChar == ' ')
                            { break; }


                        }

                    }
                    //Console.WriteLine(count);}
                }

                
                    Console.Write(text.ElementAt(i));
                


            }


            Console.ReadKey();


            }



        //zad5
        static void Filtr()
        {
            string[] textIN = System.IO.File.ReadAllLines("plik2.txt");
            System.IO.File.WriteAllText("plik3.txt", String.Empty);
            foreach(string line in textIN)
            {
                bool czyliczba = Double.TryParse(line, out double pom);
                if(czyliczba)
                {

                    //tekst +=  pom.ToString() + "\n";
                    System.IO.File.AppendAllText("plik3.txt", pom.ToString());
                    System.IO.File.AppendAllText("plik3.txt", Environment.NewLine);

                }
                
            }

         
            Console.ReadKey();



        }

        //zad6
        static void Ksiazka()
        {



            Regex dopasowanie = new Regex(@"^\d{3}\-\d{3}\-\d{3}$");                                           
            string przyklad = "733-053-631";
            Match czyok = dopasowanie.Match(przyklad);
            if(czyok.Success)
            { Console.Write("GIIIIIIIT"); }

            Console.ReadKey();

            //

            Console.WriteLine("KSIAZKA TELEFONICZNA (odczytuje z pliku)");
            string[] raw = System.IO.File.ReadAllLines("ksiazka.txt");
            
            Wpis[] ksiega = new Wpis[100];
            for(int pom =0; pom<100; pom++)
            { ksiega[pom] = new Wpis(); }
            
            int i = 0;
            
            
                
            foreach(string line in raw)
            {
                ksiega[i].ustawImie(line.Split(',')[0]);
                ksiega[i].ustawNumer(line.Split(',')[1].Replace(" ", String.Empty));

                Console.WriteLine("WPIS " + i + "imie: "+ksiega[i].imie +"numer: "+ ksiega[i].numer);
            }

            Console.ReadKey();
        }


        //zad7
        static void Totek()
        {
            Random losowa = new Random();

            Console.WriteLine("Podaj 6 liczb zakres 1-49");

            int[] wybor = new int[6];
            int pom;
            for(int i=0; i<6; i++)
            {
                Console.WriteLine("Liczba nr " + (i + 1));
                while (true)
                {
                    pom = int.Parse(Console.ReadLine());
                    if ((pom > 0 && pom < 50) && (!wybor.Contains(pom))) 
                    {
                        wybor[i] = pom;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Liczba ktora podales jest ze zlego przedzialu, lub zostala podana wczesniej!");
                    }
                }             
            }
            Console.WriteLine("OK, wybrales liczby: ");
            Array.Sort(wybor);
            foreach (int element in wybor) { Console.WriteLine(element.ToString()); }     
            
            //losowanie
            int trafione = 0;
            int[] lotek = new int[6];
            Console.WriteLine("Wylosowane liczby: ");
            for(int i = 0; i<lotek.Length; i++)
            {
                lotek[i] = losowa.Next(1, 49);
                
                if(wybor.Contains(lotek[i]))
                {
                    trafione++;

                }

            }

            Array.Sort(lotek);
            for(int i = 0; i< lotek.Length; i++)
            {
                Console.WriteLine(lotek[i]);
            }

            Console.WriteLine("Udalo ci sie trafic " + trafione);
            Console.ReadKey();

        }

       

    }



}
