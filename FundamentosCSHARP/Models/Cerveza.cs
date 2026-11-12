using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHARP.Models
{
    // HERENCIA: es una Bebida. INTERFAZ: cumple el contrato IBebidaAlcoholica.
    class Cerveza : Bebida, IBebidaAlcoholica
    {
        // Valor de ejemplo, expresado como porcentaje.
        public int Alcohol { get; } = 5;

        public string DescribirAlcohol()
        {
            return $"{Nombre}: {Alcohol}% de alcohol.";
        }
        public Cerveza(int cantidad, string nombre = "Cerveza")
            : base(nombre, cantidad)
        {
        }

        // POLIMORFISMO: reemplaza la descripcion heredada de Bebida.
        public override string Describir()
        {
            return $"Cerveza - {base.Describir()} Alcohol: {Alcohol}%.";
        }
    }
}

