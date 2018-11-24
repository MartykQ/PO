using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    interface IZapisywalna
    {
        void ZapiszBIN(string nazwa);
        Object OdczytajBIN(string nazwa);
    }
}
