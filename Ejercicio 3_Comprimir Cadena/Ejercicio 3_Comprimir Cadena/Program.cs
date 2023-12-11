using System;
using System.Text;

namespace Ejercicio_3_Comprimir_Cadena
{
    class Program
    {
        static string ComprimirCadena(string cadena)
        {
            int longitudOriginal = cadena.Length;

            if (longitudOriginal <= 2)
            {
                return cadena; // Si la cadena tiene 2 caracteres o menos, no se puede comprimir más
            }

            StringBuilder comprimida = new StringBuilder();
            int contador = 1;

            for (int i = 1; i < longitudOriginal; i++)
            {
                // Si el carácter actual es igual al anterior, incrementar el contador
                if (cadena[i] == cadena[i - 1])
                {
                    contador++;
                }
                else
                {
                    // Si el carácter cambió, añadir el carácter anterior y su contador a la cadena comprimida
                    comprimida.Append(cadena[i - 1]);
                    comprimida.Append(contador);
                    contador = 1; // Restablecer el contador para el nuevo carácter
                }
            }

            // Añadir el último carácter y su contador a la cadena comprimida
            comprimida.Append(cadena[longitudOriginal - 1]);
            comprimida.Append(contador);

            // Devolver la cadena original si la comprimida no es más corta
            return comprimida.Length >= longitudOriginal ? cadena : comprimida.ToString();
        }

        static void Main(string[] args)
        {
            string cadena = "aaabbbcc"; // Cambiar la cadena a comprimir según sea necesario

            string cadenaComprimida = ComprimirCadena(cadena);

            Console.WriteLine("Cadena original: " + cadena);
            Console.WriteLine("Cadena comprimida: " + cadenaComprimida);

            Console.ReadKey();
        }
    }
}
