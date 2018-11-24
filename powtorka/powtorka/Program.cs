using System;
using System.Collections;
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
            poj1.DodajString("jeden");
            poj1.DodajString("dwa");
            poj1.WstawIndeks(0, "naZero");
            
            PojemnikNaLancuchy poj2 = (PojemnikNaLancuchy)poj1.Clone();
            poj2.Zamien("dwa", "zamieniony");
           

            Console.WriteLine(poj1);
            Console.WriteLine("==============");
            Console.WriteLine(poj2);
            Console.WriteLine(poj1.Equals(poj2));
            
            PojemnikNaLancuchy p1 = new PojemnikNaLancuchy("p1", "a");
            PojemnikNaLancuchy p2 = new PojemnikNaLancuchy("p2", "b");
            PojemnikNaLancuchy p3 = new PojemnikNaLancuchy("p3", "c");
            
   
          

            
            Console.WriteLine("xDxDxDxDxD");

            ArrayList sortowalna = new ArrayList();
            sortowalna.Add(p3);
            sortowalna.Add(p2);
            sortowalna.Add(p1);


            sortowalna.Sort();
            
            foreach(PojemnikNaLancuchy p in sortowalna)
            {
                Console.WriteLine(p);
            }


            poj1.ZapiszXML("nowyPlik");
            
            PojemnikNaLancuchy poj3 = (PojemnikNaLancuchy)PojemnikNaLancuchy.WczytajXML("nowyPlik");
            Console.WriteLine(poj3);
            Console.ReadKey();
            
        }
    }
}
