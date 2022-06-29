using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays_and_lists
{
    public class CommonElements
    {
        static public void Main() {
            List<string> arr_1 = new List<string>();
            List<string> arr_2= new List<string>();

            arr_1 = Console.ReadLine()?.Split(" ").ToList();
            arr_2 = Console.ReadLine()?.Split(" ").ToList();

            for (int i = 0; i < arr_2.Count; i++) {
                for (int j = 0; j < arr_1.Count; j++) {
                    if (arr_2[i].Equals(arr_1[j])) {
                        Console.Write(arr_2[i] + " ");
                    }
                }
            }
        }
    }
}