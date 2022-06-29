using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays_and_lists
{
    public class ChangingList
    {
        public static void Main() {
            List<int> lst = new List<int>();
            lst = Console.ReadLine()?.Split(" ").Select(int.Parse).ToList();

            string input = Console.ReadLine();
            while (input != null && !input.Equals("end")) {
                if (input.Contains("Insert")) {
                    int value = int.Parse(input.Split(" ")[1]);
                    int index = int.Parse(input.Split(" ")[2]);
                    
                    lst?.Insert(index, value);
                } 
                else if (input.Contains("Delete")) {
                    int value = int.Parse(input.Split(" ")[1]);

                    while (lst != null && lst.Contains(value)) {
                        lst.Remove(value);
                    }
                }
                input = Console.ReadLine();
            }

            Console.Write('\n');
            if (lst != null)
                foreach (var elem in lst) {
                    Console.Write(elem + " ");
                }
        }
    }
}