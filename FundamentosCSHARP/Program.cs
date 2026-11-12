using System;
using FundamentosCSHARP.Models;


namespace FundamentosCSHARP
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            // La opcion --bd permite practicar SQL sin cambiar los ejercicios de POO.
            if (args.Length > 0 && args[0] == "--bd")
                return await EjemploBaseDeDatosAsync(args.Length > 1 ? args[1] : null);

            //// Tipos de datos
            //byte numeroByte = 255; // 0 a 255
            //sbyte numeroSByte = -128; // -128 a 127
            //int numeroInt = 2147483647; // -2,147,483,648 a 2,147,483,647 
            //uint numeroUInt = 4294967295; // 0 a 4,294,967,295
            //ulong numeroULong = 18446744073709551615; // 0 a 18,446,744,073,709,551,615
            //long numeroLong = -9223372036854775808; // -9,223,372,036,854,775,808 a 9,223,372,036,854,775,807
            //short numeroShort = -32768; // -32,768 a 32,767
            //ushort numeroUShort = 65535; // 0 a 65,535  

            //// Tipos de datos decimales
            //float numeroFloat = 3.402823e38f; // 1.5e-45 a 3.4e38 4 bites
            //double numeroDouble = 1.7976931348623157e308; // 5.0e-324 a 1.7e308 8 bites
            //decimal numeroDecimal = 79228162514264337593543950335m; // 1.0e-28 a 7.9e28 16 bites

            //// tipos de datos string y char
            //string texto = "Hola, mundo!"; // PUEDES almacenar hasta 2 mil millones de caracteres
            //char caracter = 'A'; // puedes almacenar un solo caracter

            //// Tipos de datos booleanos
            //bool esVerdadero = true; // puede ser true o false

            //// Tipos de datos fecha y hora
            //DateTime fechaHora = DateTime.Now; // almacena fecha y hora actual

            // Creacion del objeto de la clase Bebida
            Bebida bebida = new Bebida("Coca cola", 1000);
            // Cantidad se consulta desde fuera; Beberse controla su modificacion.
            bebida.Beberse(500);
            Console.WriteLine(bebida.Cantidad);

            //Herencia
            Bebida cerveza = new Cerveza(300);
            cerveza.Beberse(100);
            Console.WriteLine(cerveza.Cantidad);

            //coleccion de datos Array
            int[] numeros = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            // recorrer con for 
            for (int i = 0; i < numeros.Length; i++)
            {
                Console.WriteLine("iteracion: " + i + " - " + numeros[i]);
            }

            //recorrer con foreach

            foreach (var numero in numeros) // var numero es una variable temporal que almacena el valor de cada elemento del array numeros
            {
                Console.WriteLine("iteracion: " + numero);
            }

            // Listado de datos List
            Console.WriteLine("*************************************");
            List<int> lista = new List<int>() { 1, 2, 3, 5, 5, 6, 7, 8 };
            lista.Add(9); // Agregar un elemento al final de la lista
            lista.Add(10);
            lista.Remove(2);// Eliminar un elemento de la lista

            foreach (var numero in lista) // var numero es una variable temporal que almacena el valor de cada elemento del array numeros
            {
                Console.WriteLine("elemento: " + numero);
            }
            //Lista de clases
            List<Cerveza> cervezas = new List<Cerveza>() { new Cerveza(10,"Cerveza Premium") };
            cervezas.Add(new Cerveza(500));
            Cerveza erdinger = new Cerveza(500, "Cerveza de trigo");
            cervezas.Add(erdinger);

            foreach (var cervezaActual in cervezas)
            {
                Console.WriteLine("Nombre: " + cervezaActual.Nombre + " - Cantidad: " + cervezaActual.Cantidad);
            }

            EjemploPoo();
            return 0;
        }

        static async Task<int> EjemploBaseDeDatosAsync(string? marca)
        {
            // La contrasena no se guarda en el codigo ni en GitHub.
            string? conexion = Environment.GetEnvironmentVariable("FUNDAMENTOS_DB");
            if (string.IsNullOrWhiteSpace(conexion))
            {
                Console.Error.WriteLine("Configura FUNDAMENTOS_DB como se explica en el README.");
                return 1;
            }

            try
            {
                // El programa es propietario de la fuente y la libera al terminar.
                await using var dataSource = Npgsql.NpgsqlDataSource.Create(conexion);
                CervezaBD baseDeDatos = new CervezaBD(dataSource);
                List<Cerveza> cervezas = await baseDeDatos.GetAsync(marca);

                Console.WriteLine($"Cervezas encontradas: {cervezas.Count}");
                foreach (Cerveza cerveza in cervezas)
                    Console.WriteLine($"{cerveza.Describir()} Marca: {cerveza.Marca}.");
                return 0;
            }
            catch (Npgsql.PostgresException error)
            {
                // El codigo SQLSTATE ayuda a diagnosticar sin mostrar credenciales.
                Console.Error.WriteLine($"PostgreSQL rechazo la consulta (SQLSTATE {error.SqlState}). Revisa la tabla del script SQL.");
                return 1;
            }
            catch (Npgsql.NpgsqlException)
            {
                Console.Error.WriteLine("No se pudo conectar a PostgreSQL. Revisa el servicio y FUNDAMENTOS_DB.");
                return 1;
            }
            catch (ArgumentException)
            {
                Console.Error.WriteLine("La configuracion de conexion o los datos recibidos no son validos.");
                return 1;
            }
        }

        static void EjemploPoo()
        {
            Console.WriteLine("\n=== EJEMPLO DE PROGRAMACION ORIENTADA A OBJETOS ===");

            // 1. CLASES, OBJETOS Y CONSTRUCTORES: new crea objetos independientes.
            Cerveza cerveza = new Cerveza(300, "Cerveza artesanal");
            Vino vino = new Vino(750, "Vino tinto");

            // 2. HERENCIA Y POLIMORFISMO: diferentes objetos tratados como Bebida.
            List<Bebida> bebidas = new List<Bebida>
            {
                new Bebida("Agua", 1000),
                cerveza,
                vino
            };

            Console.WriteLine("\nHerencia y polimorfismo con virtual / override:");
            foreach (Bebida bebida in bebidas)
            {
                Console.WriteLine(bebida.Describir());
            }

            // 3. INTERFACES: usamos el contrato sin depender de una clase concreta.
            List<IBebidaAlcoholica> bebidasAlcoholicas = new List<IBebidaAlcoholica>
            {
                cerveza,
                vino
            };

            Console.WriteLine("\nPolimorfismo mediante una interfaz:");
            foreach (IBebidaAlcoholica bebidaAlcoholica in bebidasAlcoholicas)
            {
                Console.WriteLine(bebidaAlcoholica.DescribirAlcohol());
            }

            // 4. ENCAPSULAMIENTO: el metodo protege el estado del objeto.
            Console.WriteLine("\nEncapsulamiento:");
            cerveza.Beberse(100);
            Console.WriteLine($"Despues de beber 100 ml quedan {cerveza.Cantidad} ml.");
            // cerveza.Cantidad = -100; // No compila: el set es privado.

            try
            {
                cerveza.Beberse(500); // Se rechaza porque solo quedan 200 ml.
            }
            catch (InvalidOperationException error)
            {
                Console.WriteLine($"Operacion rechazada: {error.Message}");
            }
            Console.WriteLine($"La cantidad sigue siendo {cerveza.Cantidad} ml.");

            // 5. COMPOSICION DE OBJETOS: la nevera contiene las mismas bebidas.
            Console.WriteLine("\nContenido de la nevera:");
            Nevera nevera = new Nevera();
            foreach (Bebida bebida in bebidas)
            {
                nevera.Agregar(bebida);
            }
            nevera.MostrarContenido();
        }

    }
}
