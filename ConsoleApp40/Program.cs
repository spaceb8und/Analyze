using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays_and_lists
{
    public class BigNumbers
    {
        public static void Main() {
            List<Int32> input = new List<int>();
            input = Console.ReadLine()?.Split(" ").Select(int.Parse).ToList();

            for (int i = 0; i < input.Count - 1; i++) {
                for (int j = i + 1; j < input.Count; j++) {
                    if (input[i] <= input[j]) {
                        break;
                    }

                    if (j == input.Count - 1) {
                        Console.Write(input[i] + " ");
                    }
                }
            }
            Console.Write(input[^1]); // use index from end collection
        }
    }
}