using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHARP.Models
{
    class Cerveza : Bebida
    {
        public Cerveza(int cantidad, string nombre = "Cerveza")
            : base(nombre, cantidad)
        {
        }
    }
}

