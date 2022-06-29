using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays_and_lists
{
    public class MagicSum
    {
        public static void  Main() {
            List<int> array = new List<int>();
            array = Console.ReadLine()?.Split(" ").Select(int.Parse).ToList();

            int n = int.Parse(Console.ReadLine() ?? string.Empty);

            if (array != null)
                for (int i = 0; i < array.Count - 1; i++) {
                    for (int j = i + 1; j < array.Count; j++) {
                        if (array[i] + array[j] == n) {
                            Console.Write(array[i] + " " + array[j] + '\n');
                        }
                    }
                }
        }
    }
}