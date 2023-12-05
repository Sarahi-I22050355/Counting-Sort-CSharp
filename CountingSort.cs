using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counting_Sort
{
    internal class CountingSort
    {
        public static int[] Sort(int[] inputArray)
        {
            // Encontrar el elemento máximo de inputArray.
            int M = 0;
            foreach (int num in inputArray)
            {
                if (num > M)
                {
                    M = num;
                }
            }

            // Inicializar countArray con 0
            int[] countArray = new int[M + 1];

            // Asignar cada elemento de inputArray como un índice de countArray
            foreach (int num in inputArray)
            {
                countArray[num]++;
            }

            // Calcular la suma prefija en cada índice de countArray
            for (int i = 1; i < M + 1; i++)
            {
                countArray[i] += countArray[i - 1];
            }

            // Crear outputArray a partir de countArray
            int[] outputArray = new int[inputArray.Length];

            for (int i = inputArray.Length - 1; i >= 0; i--)
            {
                outputArray[countArray[inputArray[i]] - 1] = inputArray[i];
                countArray[inputArray[i]]--;
            }

            return outputArray;
        }

        public static string[] SortStrings(string[] inputArray)
        {
            // Encontrar la cadena más larga en inputArray.
            int maxLength = 0;
            foreach (string str in inputArray)
            {
                if (str.Length > maxLength)
                {
                    maxLength = str.Length;
                }
            }

            // Inicializar countArray con 0
            int range = 256; // Considerando el rango ASCII extendido
            int[][] countArray = new int[inputArray.Length][];
            for (int i = 0; i < inputArray.Length; i++)
            {
                countArray[i] = new int[range];
            }

            // Contar la frecuencia de cada carácter en cada string
            for (int i = 0; i < inputArray.Length; i++)
            {
                foreach (char c in inputArray[i])
                {
                    countArray[i][c]++;
                }
            }

            // Calcular la suma prefija en cada índice de countArray
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 1; j < range; j++)
                {
                    countArray[i][j] += countArray[i][j - 1];
                }
            }

            // Crear outputArray a partir de countArray
            string[] outputArray = new string[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
            {
                char[] sortedString = new char[maxLength];

                for (int j = inputArray[i].Length - 1; j >= 0; j--)
                {
                    int index = --countArray[i][inputArray[i][j]];
                    sortedString[index] = inputArray[i][j];
                }

                outputArray[i] = new string(sortedString);
            }

            return outputArray;
        }
    }
}
