﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql

{
    interface IZapisywalna
    {
        void ZapiszBIN(string nazwa);
        Object OdczytajBIN(string nazwa);
    }
}
