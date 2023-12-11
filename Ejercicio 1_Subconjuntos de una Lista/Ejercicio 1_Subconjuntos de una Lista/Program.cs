using System;
using System.Collections.Generic;

namespace Ejercicio_1_Subconjuntos_de_una_Lista
{
    class Program
    {
        static void Main()
        {
            // Crear una lista de enteros
            List<int> miLista = new List<int> { 1, 2, 3 };
            // Obtener todos los subconjuntos posibles de la lista
            List<List<int>> subconjuntos = ObtenerSubconjuntos(miLista);

            Console.WriteLine("Subconjuntos posibles:");
            // Mostrar cada subconjunto en la consola
            foreach (var subconjunto in subconjuntos)
            {
                Console.WriteLine($"{{{string.Join(", ", subconjunto)}}}");
            }

            // Esperar a que el usuario presione una tecla antes de cerrar la consola
            Console.ReadKey();
        }

        // Función para obtener todos los subconjuntos de una lista dada
        static List<List<T>> ObtenerSubconjuntos<T>(List<T> lista)
        {
            List<List<T>> subconjuntos = new List<List<T>>();
            int totalSubconjuntos = 1 << lista.Count; 

            for (int i = 0; i < totalSubconjuntos; i++)
            {
                List<T> subconjunto = new List<T>();

             
                for (int j = 0; j < lista.Count; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        subconjunto.Add(lista[j]);
                    }
                }

                subconjuntos.Add(subconjunto);
            }

            return subconjuntos;
        }
    }
}
