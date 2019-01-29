using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgzUlamek
{
    public class Ulamek
    {
        private int licznik;
        private int mianownik;

        public int Licznik { get => licznik; set => licznik = value; }
        public int Mianownik { get => mianownik; set => mianownik = value; }

        public Ulamek(int licz, int mian)
        {
            licznik = licz;
            if (mian == 0)
                throw new DivideByZeroException("Nie mozna dziel przez 0");

            else
                mianownik = mian;
        }


        public void Skroc()
        {
            if(licznik!=mianownik)
            {
                //dzielimy licznik i mianownik przez NWD
                int dzielnik = ZnajdzNWD(this.licznik, this.mianownik);
                licznik = licznik / dzielnik;
                mianownik = mianownik / dzielnik;
            }

            else
            {
                licznik = 1;
                mianownik = 1;
            }

        }

        public static Ulamek DodajUlamki(Ulamek u1, Ulamek u2)
        {
            int nowyLicznik;
            int nowyMianownik;

            if(u1.Mianownik == u2.Mianownik)
            {
                nowyMianownik = u1.Mianownik;
                nowyLicznik = u1.Licznik + u2.Licznik;
            }

            else
            {
                nowyMianownik = u1.Mianownik * u2.Mianownik;
                nowyLicznik = u1.Licznik * u2.Mianownik + u2.Licznik * u1.Mianownik;
            }

            return new Ulamek(nowyLicznik, nowyMianownik);

        }

        public static Ulamek PomnozUlamek(Ulamek u1, Ulamek u2)
        {
            return new Ulamek(u1.Licznik * u2.Licznik, u1.Mianownik * u2.Mianownik);
        }


        public static int ZnajdzNWD(int a, int b)
        {

            while(a!=b)
            {
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
             
            }
            return a;

        }
    }
}
