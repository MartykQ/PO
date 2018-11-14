using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class PeselException:Exception
    {

        public PeselException(string message) : base(message)
        {

        }
    }

}
