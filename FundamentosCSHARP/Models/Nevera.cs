namespace FundamentosCSHARP.Models
{
    // COMPOSICION: una Nevera tiene bebidas; no hereda de Bebida.
    // Como las bebidas tambien pueden existir fuera, esta relacion se conoce
    // mas precisamente como agregacion.
    class Nevera
    {
        // private impide que otras clases modifiquen directamente la lista.
        // readonly impide reemplazar la lista, pero permite agregar elementos.
        private readonly List<Bebida> bebidas = new List<Bebida>();

        public void Agregar(Bebida bebida)
        {
            ArgumentNullException.ThrowIfNull(bebida);
            bebidas.Add(bebida);
        }

        public void MostrarContenido()
        {
            foreach (Bebida bebida in bebidas)
            {
                // Se ejecuta la version de Describir del objeto real.
                Console.WriteLine(bebida.Describir());
            }
        }
    }
}
