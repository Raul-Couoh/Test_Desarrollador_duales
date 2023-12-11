using System;

namespace Ejercicio_2_Buscar_Palabra_en_Matriz
{
    class Program
    {
        // Función para buscar una palabra en una matriz en todas las direcciones posibles
        static bool BuscarPalabra(char[,] matriz, string palabra)
        {
            // Obtener las dimensiones de la matriz
            int filas = matriz.GetLength(0);
            int columnas = matriz.GetLength(1);

            // Convertir la palabra a mayúsculas para POder realizar una comparación sin distinción de mayúsculas y minúsculas
            palabra = palabra.ToUpper();

            // Recorrer la matriz para buscar la palabra en todas las direcciones
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    // Comenzar la búsqueda desde cada posición
                    if (matriz[i, j] == palabra[0]) // Verificar si la primera letra coincide
                    {
                        // Llamar a la función Buscar Desde una Posicion para verificar la si esixte esa palabra
                        if (BuscarDesdePosicion(matriz, palabra, i, j))
                        {
                            return true; // Si se encuentra la palabra, devolver verdadero
                        }
                    }
                }
            }
            return false; // Si no se encuentra la palabra en ninguna dirección, devolver falso
        }

        // Función para buscar una palabra desde una posición específica en todas las direcciones
        static bool BuscarDesdePosicion(char[,] matriz, string palabra, int fila, int columna)
        {
            // Obtener las dimensiones de la matriz
            int filas = matriz.GetLength(0);
            int columnas = matriz.GetLength(1);
            int longitud = palabra.Length; // Longitud de la palabra buscada

            // Definir los cambios en filas y columnas para las 8 direcciones posibles
            int[] dirFilas = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] dirColumnas = { -1, 0, 1, -1, 1, -1, 0, 1 };

            // Probar todas las 8 direcciones desde la posición actual
            for (int dir = 0; dir < 8; dir++)
            {
                int k = 1; // Iniciar en uno para comparar desde la segunda letra de la palabra

                int r = fila + dirFilas[dir]; // Actualizar la fila según sea la dirección
                int c = columna + dirColumnas[dir]; // Actualizar la columna según sea la dirección

                // Verificar si la palabra se puede encontrar en la dirección actual
                while (k < longitud && r >= 0 && r < filas && c >= 0 && c < columnas && palabra[k] == matriz[r, c])
                {
                    // Moverse en la dirección actual
                    k++;
                    r += dirFilas[dir];
                    c += dirColumnas[dir];
                }

                if (k == longitud)
                {
                    return true;
                }
            }

            return false; // Si la palabra no se encuentra en ninguna dirección, devolver falso
        }

        static void Main(string[] args)
        {
            char[,] matriz = {
                {'A', 'B', 'C', 'D'},
                {'E', 'F', 'G', 'H'},
                {'I', 'J', 'K', 'L'},
                {'M', 'N', 'O', 'P'}
            };

            string palabraBuscada = "AFKP"; // Palabra que se buscará en la matriz

            bool encontrada = BuscarPalabra(matriz, palabraBuscada); // Llamar a la función para buscar la palabra

            // Mostrar si se encontró o no la palabra en la matriz
            if (encontrada)
            {
                Console.WriteLine("La palabra \"{0}\" se encuentra en la matriz.", palabraBuscada);
            }
            else
            {
                Console.WriteLine("La palabra \"{0}\" no se encuentra en la matriz.", palabraBuscada);
            }

            Console.ReadKey();
        }
    }
}
