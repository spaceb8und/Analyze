using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays_and_lists
{
    public class WorkingWithList
    {
        public static void Main() {
            List<int> lst = new List<int>();
            lst = Console.ReadLine()?.Split(" ").Select(int.Parse).ToList();

            string input = Console.ReadLine();
            while (!input.Equals("End")) {
                string function = input.Split(" ")[0];
                switch (function) {
                    case "Insert": {
                        int value = int.Parse(input.Split(" ")[1]);
                        int index = int.Parse(input.Split(" ")[2]);
                        if (index >= lst.Count || index < 0) {
                            Console.WriteLine("Invalid index!");
                            break;
                        }
                        lst?.Insert(index, value);
                        break;
                    }
                    case "Add": {
                        int value = int.Parse(input.Split(" ")[1]);
                        lst?.Add(value);
                        break;
                    }
                    case "Remove": {
                        int index = int.Parse(input.Split(" ")[1]);
                        if (index >= lst.Count || index < 0) {
                            Console.WriteLine("Invalid index!");
                            break;
                        }
                        lst?.RemoveAt(index);
                        break;
                    }
                    case "Shift": {
                        int rotations = int.Parse(input.Split(" ")[2]);
                        if (input.Split(" ")[1].Equals("left")) {
                            for (int i = 0; i < rotations; i++) {
                                for (int j = 0; j < lst.Count - 1; j++) {
                                    (lst[j], lst[j + 1]) = (lst[j + 1], lst[j]);
                                }
                            }
                        }
                        else {
                            for (int i = 0; i < rotations; i++) {
                                for (int j = lst.Count - 1; j > 0; j--) {
                                    (lst[j], lst[j - 1]) = (lst[j - 1], lst[j]);
                                }
                            }
                        }
                        break;
                    }
                }
                input = Console.ReadLine();
            }
            
            Console.Write('\n');
            foreach (var elem in lst) {
                Console.Write(elem + " ");
            }
        }
    }
}