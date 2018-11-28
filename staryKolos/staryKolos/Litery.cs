using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staryKolos
{
    class Litery: Znaki
    {
        private ArrayList kolekcjaLiter;

        public ArrayList KolekcjaLiter { get => kolekcjaLiter; set => kolekcjaLiter = value; }



        public Litery(): base()
        {
            KolekcjaLiter = new ArrayList();
        }

        

        public override void DodajZnak(char znak)
        {
            if (Char.IsLetter(znak))
            {
                KolekcjaZnakow.Add(znak);

            }
            else throw new NotLiteralException("To nie litera");
        }

    }
}
