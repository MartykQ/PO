using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw8

{
    class wronPESELExcepition:Exception
    {
        public wronPESELExcepition() : base()
        {
            Console.WriteLine(" Niepoprawny numer PESEL ! ");
        }
    }
}
