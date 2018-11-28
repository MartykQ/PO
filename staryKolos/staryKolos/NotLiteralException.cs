using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staryKolos
{
    class NotLiteralException: Exception
    {
        public NotLiteralException(string message): base(message)
        {
            ;
        }
    }
}
