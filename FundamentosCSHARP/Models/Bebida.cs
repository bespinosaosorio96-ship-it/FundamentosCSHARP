using System;
using System.Collections.Generic;
using System.Text;

namespace FundamentosCSHARP.Models
{
    // ABSTRACCION: representa los datos y comportamientos comunes de una bebida.
    class Bebida
    {
        public string Nombre { get; }
        // ENCAPSULAMIENTO: desde fuera se puede leer, pero no asignar la cantidad.
        public int Cantidad { get; private set; }

        //Constructor

        public Bebida(string nombre, int cantidad)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("La bebida debe tener un nombre.", nameof(nombre));
            if (cantidad < 0)
                throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad no puede ser negativa.");

            Nombre = nombre;
            Cantidad = cantidad;
        }

        public void Beberse(int cuantoBebio)
        
        {
            if (cuantoBebio <= 0)
                throw new ArgumentOutOfRangeException(nameof(cuantoBebio), "Debes beber una cantidad positiva.");
            if (cuantoBebio > Cantidad)
                throw new InvalidOperationException("No hay suficiente bebida.");

            Cantidad -= cuantoBebio;
        }

        // virtual permite que las clases hijas ofrezcan su propia descripcion.
        public virtual string Describir()
        {
            return $"{Nombre}: quedan {Cantidad} ml.";
        }



    }
}
