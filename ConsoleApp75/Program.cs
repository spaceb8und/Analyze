using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StupidSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];
            Random rand = new Random();

            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next(0, 10);

            Console.WriteLine("Исходная последовательность:");
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");

            stupidSort(array);

            Console.WriteLine("\nОтсортированная последовательность:");
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");

            Console.ReadLine();
        }

        static void stupidSort(int[] arr)
        {
            int i = 0, tmp;
            while (i < arr.Length - 1)
            {
                if (arr[i + 1] < arr[i])
                {
                    tmp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = tmp;
                    i = 0;
                }
                else i++;
            }
        }

    }
}