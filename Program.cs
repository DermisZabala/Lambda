using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Channels;

namespace Lambdas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //Pasandole por parametro a la coleccion Numeros una expresion Lambda para simplificar el codigo
            List<int> numerosPares = Numeros.FindAll(i => i % 2 == 0);

            Console.WriteLine("\nNumeros Pares");
            numerosPares.ForEach(elemento => Console.WriteLine(elemento));

            //Utilizando la expresion Lambda para simplificar el codigo
            List<int> numerosPrimos = Numeros.FindAll(z =>
            {
                if (z < 2) return false;

                for (int i = 2; i <= Math.Sqrt(z); i++)
                {
                    if (z % i == 0)
                        return false;
                };

                return true;
            }
            );


            Console.WriteLine("\nNumeros Primos");
            foreach (int elementos in numerosPrimos)
            {
                Console.WriteLine(elementos);
            }

            Personas p1 = new();
            Personas p2 = new();
            Personas p3 = new();

            p1.Nombre = "Hamel";
            p1.EDAD = 19;

            p2.Nombre = "Dermis";
            p2.EDAD = 19;

            Console.WriteLine("\nEvaluando personas");
            EvaluandoPersonas evaluandoEdades = (persona1, persona2) => persona1 == persona2;

            Console.WriteLine($"¿{p1.Nombre} y {p2.Nombre} tienen la misma edad? {evaluandoEdades(p1.EDAD, p2.EDAD)}");
            Console.WriteLine($"Edad de {p1.Nombre}: {p1.EDAD}");
            Console.WriteLine($"Edad de {p2.Nombre}: {p2.EDAD}");

            Console.ReadKey();

        }
        public delegate bool EvaluandoPersonas(int edad1, int edad2);
    }

    class Personas
    {
        private string nombre;
        private int edad;

        
        public int EDAD
        {
            get { return edad; }
            set { edad = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}
