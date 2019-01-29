using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql

{
    class wronPESELExcepition:Exception
    {
        public wronPESELExcepition() : base()
        {
            Console.WriteLine(" Niepoprawny numer PESEL ! ");
        }
    }
}
