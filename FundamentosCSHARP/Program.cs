using System;
using FundamentosCSHARP.Models;

namespace FundamentosCSHARP
{
    class Program
    {
        static void Main(string[] args)
    {
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
            // puedo asignar por que tengo atributo publico si fuese privado no podria asignar
            bebida.Beberse(500);
            Console.WriteLine(bebida.Cantidad);

            //Herencia
            Bebida cerveza = new Cerveza();
            cerveza.Beberse(100);
            Console.WriteLine(cerveza.Cantidad);

        }
    }
}
