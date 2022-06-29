using System;

namespace Arrays_and_lists
{
    public class Train
    {
        public static void Main() {
            Int32 n = Convert.ToInt32(Console.ReadLine());

            Int32[] pass = new int[n];
            for (int i = 0; i < n; i++) {
                pass[i] = Convert.ToInt32(Console.ReadLine());
            }

            int sum = 0;
            foreach (Int32 passenger in pass) {
                Console.Write(passenger + " ");
                sum += passenger;
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}