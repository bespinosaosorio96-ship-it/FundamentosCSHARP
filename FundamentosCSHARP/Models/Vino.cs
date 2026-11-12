using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHARP.Models
{
    class Vino : Bebida, IBebidaAlcoholica
    {
        // Valor de ejemplo, expresado como porcentaje.
        public int Alcohol { get; } = 12;

        public string DescribirAlcohol()
        {
            return $"{Nombre}: {Alcohol}% de alcohol.";

        }
        public Vino(int cantidad, string nombre = "Vino")
            : base(nombre, cantidad)
        {
        }

        public override string Describir()
        {
            return $"Vino - {base.Describir()} Alcohol: {Alcohol}%.";
        }
    }
}

