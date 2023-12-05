using System.Diagnostics;

namespace Counting_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] inputArray = new int[10];

            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = rnd.Next(101); // Genera un número aleatorio entre 0 y 100
            }

            // Mostrar el array generado aleatoriamente
            Console.WriteLine("Array generado aleatoriamente:");
            foreach (int num in inputArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Iniciar el cronómetro para medir el tiempo
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Ordenar el array utilizando CountingSort
            int[] outputArray = CountingSort.Sort(inputArray);

            // Detener el cronómetro
            stopwatch.Stop();

            // Mostrar el array ordenado
            Console.WriteLine("\nArray ordenado:");
            foreach (int num in outputArray)
            {
                Console.Write(num + " ");
            }

            // Mostrar el tiempo transcurrido
            Console.WriteLine($"\n\nTiempo transcurrido en ordenar: {stopwatch.Elapsed}");

            // Permitir al usuario ingresar una cadena para ordenarla
            Console.WriteLine("\nIngrese una cadena para ordenarla por caracteres ASCII:");
            string userString = Console.ReadLine();

            string[] userArray = new string[] { userString };
            string[] sortedUserArray = CountingSort.SortStrings(userArray);

            // Mostrar la cadena ordenada
            Console.WriteLine("\nCadena ordenada:");
            Console.WriteLine(sortedUserArray[0]);
        }
    }
}