using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHARP.Models
{
    // INTERFAZ: define un contrato; no guarda el estado de las bebidas.
    interface IBebidaAlcoholica
    {
        int Alcohol { get; }

        string DescribirAlcohol();
    }
}
