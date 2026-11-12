using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHARP.Models
{
    // HERENCIA: es una Bebida. INTERFAZ: cumple el contrato IBebidaAlcoholica.
    class Cerveza : Bebida, IBebidaAlcoholica
    {
        // Son de solo lectura: los valores se validan al construir el objeto.
        public int Alcohol { get; }
        public string Marca { get; }

        public string DescribirAlcohol()
        {
            return $"{Nombre}: {Alcohol}% de alcohol.";
        }
        public Cerveza(int cantidad, string nombre = "Cerveza", int alcohol = 5, string marca = "Sin marca")
            : base(nombre, cantidad)
        {
            if (alcohol < 0 || alcohol > 100)
                throw new ArgumentOutOfRangeException(nameof(alcohol), "El porcentaje debe estar entre 0 y 100.");
            if (string.IsNullOrWhiteSpace(marca))
                throw new ArgumentException("La marca no puede estar vacia.", nameof(marca));

            Alcohol = alcohol;
            Marca = marca;
        }

        // POLIMORFISMO: reemplaza la descripcion heredada de Bebida.
        public override string Describir()
        {
            return $"Cerveza - {base.Describir()} Alcohol: {Alcohol}%.";
        }
    }
}

