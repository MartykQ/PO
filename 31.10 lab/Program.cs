using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Plcie  {K=0, M=1}; 
public enum TytulW  {mgr, dr, dr_hab, prof};



namespace ConsoleApp6
{

    public struct Ocena
    {
        private string przedmiot;
        private double wartosc;

        public string Przedmiot { get => przedmiot; set => przedmiot = value; }
        public double Wartosc { get => wartosc; set => wartosc = value; }

        public Ocena(double o, string p)
        {
            przedmiot = p;
            wartosc = o;
        }


    }




    class Program
    {
        static void Main(string[] args)
        {

            
            Console.WriteLine("Siema");
            Student janek = new Student("Franek", "Martyka", "1998-05-09", "98050908638", Plcie.M, "297974");
            Console.WriteLine(janek);

            Wykladowca profesorek = new Wykladowca("Marcin", "Podstrupek", "1998-05-09", "98050908638", Plcie.M, TytulW.prof);
            Console.WriteLine(profesorek);

            Grupa grupka = new Grupa("polski", "1z2", profesorek);
            grupka.DodajStudenta(janek);
            Console.WriteLine(grupka);


            janek.DodajOcene("polski", 4.5);
            janek.DodajOcene("polski", 6.0);
            janek.DodajOcene("WF", 3);
            janek.DodajOcene("Religia", 2);

            Console.WriteLine(janek);


            grupka.DodajOcene(4, janek);

            Console.WriteLine(janek);

            Console.WriteLine(grupka.WyznaczSredniaOcen(janek).ToString());




            Console.ReadKey();

            
        }
    }
}
