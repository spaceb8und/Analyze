using System;
using System.Collections.Generic;
using System.Linq;

namespace Arrays_and_lists
{
    public class TrainWorkList
    {
        public static void Main() {
            List<int> train = new List<int>();
            train = Console.ReadLine()?.Split(" ").Select(int.Parse).ToList();

            int max = int.Parse(Console.ReadLine() ?? string.Empty);

            string input = Console.ReadLine();
            while(!input.Equals("end")) {
                if (input.Contains("Add")) {
                    int vagon = int.Parse(input.Split(" ")[1]); 
                    train?.Add(vagon);
                }
                else {
                    int passengers = int.Parse(input);
                    for (int i = 0; i < train.Count; i++) {
                        if (train[i] + passengers <= max) {
                            train[i] += passengers;
                            break;
                        }
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine();
            foreach (var vagon in train) {
                Console.Write(vagon + " ");
            }
        }
    }
}