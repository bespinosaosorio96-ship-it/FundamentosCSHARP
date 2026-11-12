using Npgsql;

namespace FundamentosCSHARP.Models
{
    // ACCESO A DATOS: esta clase consulta PostgreSQL y devuelve objetos Cerveza.
    // Cerveza representa el dominio; no necesita conocer SQL ni conexiones.
    class CervezaBD
    {
        private readonly NpgsqlDataSource dataSource;

        /// <summary>Recibe la fuente de conexiones creada por el programa.</summary>
        /// <param name="dataSource">Fuente de conexiones PostgreSQL, administrada por quien llama.</param>
        public CervezaBD(NpgsqlDataSource dataSource)
        {
            ArgumentNullException.ThrowIfNull(dataSource);
            this.dataSource = dataSource;
        }

        /// <summary>Consulta las cervezas, opcionalmente filtradas por marca.</summary>
        /// <param name="marca">Marca exacta; null devuelve todas las cervezas.</param>
        /// <returns>Una lista de objetos; queda vacia si no hay coincidencias.</returns>
        public async Task<List<Cerveza>> GetAsync(string? marca = null)
        {
            List<Cerveza> cervezas = new List<Cerveza>();

            // 1. Seleccionamos explicitamente las columnas que vamos a leer.
            string query = "SELECT nombre, marca, alcohol, cantidad FROM cervezas";
            if (marca is not null)
                query += " WHERE marca = $1";
            query += " ORDER BY nombre, marca";

            // 2. Creamos el comando. Npgsql administra la conexion necesaria.
            // await using libera recursos incluso si ocurre una excepcion.
            await using NpgsqlCommand command = dataSource.CreateCommand(query);

            // 3. Un parametro envia el valor separado del SQL, evitando inyeccion SQL.
            // No concatenamos la marca dentro del texto de la consulta.
            if (marca is not null)
                command.Parameters.AddWithValue(marca);

            // 4. ExecuteReaderAsync ejecuta el SELECT; ReadAsync avanza fila por fila.
            await using NpgsqlDataReader reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                // Los indices empiezan en cero y corresponden al orden del SELECT.
                string nombre = reader.GetString(0);
                string marcaLeida = reader.GetString(1);
                int alcohol = reader.GetInt32(2);
                int cantidad = reader.GetInt32(3);

                // 5. Transformamos una fila en un objeto, respetando su encapsulamiento.
                Cerveza cerveza = new Cerveza(cantidad, nombre, alcohol, marcaLeida);
                cervezas.Add(cerveza);
            }

            return cervezas;
        }
    }
}
