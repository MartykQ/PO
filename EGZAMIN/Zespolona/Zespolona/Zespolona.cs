using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zespolonaa
{
    public class Zespolona
    {
        private double rzeczywista;
        private double urojona;


        public double Rzeczywista { get => rzeczywista; set => rzeczywista = value; }
        public double Urojona { get => urojona; set => urojona = value; }
        
        public Zespolona(double real, double imag)
        {
            Rzeczywista = real;

            if(imag == 0)
            {
                throw new ArgumentException("Urojona rowna 0?");

            }
            else
                Urojona = imag;
        }

        public static Zespolona DodajZesp(Zespolona z1, Zespolona z2)
        {
            Zespolona z3 = new Zespolona((z1.Rzeczywista+z2.Rzeczywista), (z1.Urojona+z2.Urojona));
            return z3;
 
        }
        public static Zespolona MnozenieZesp(Zespolona z1, Zespolona z2)
        {
            Zespolona z3 = new Zespolona((z1.Rzeczywista * z2.Rzeczywista - z1.Urojona * z2.Urojona), (z1.Urojona * z2.Rzeczywista + z1.Rzeczywista * z2.Urojona));
            return z3;
        }
        public double Modul()
        {
            double c;
            c = Math.Sqrt(this.Rzeczywista * this.Rzeczywista + this.Urojona * this.Urojona);
            return c;
        }

    }
}
