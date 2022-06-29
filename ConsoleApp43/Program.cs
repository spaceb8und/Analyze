using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays_and_lists
{
    public class RotationOfArray
    {
        public static void Main()
        {
            List<int> array = new List<int>();
            array = Console.ReadLine()?.Split(" ").Select(int.Parse).ToList();
            int rotations = int.Parse(Console.ReadLine() ?? string.Empty);

            for (int i = 0; i < rotations; i++)
            {
                for (int j = 0; j < array.Count - 1; j++)
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }

            foreach (var elem in array)
            {
                Console.Write(elem + " ");
            }
        }
    }
}