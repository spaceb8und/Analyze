using System;
 
namespace Divider
{
    class DivideIt
    {
        static void Main(string[] args)
        {
            int i, j;
            string temp;
            // Here you can enter the divisor and the divisible
            Console.WriteLine("Please enter first number");
            temp = Console.ReadLine();
            i = Convert.ToInt32(temp);
            Console.WriteLine("Please enter second number");
            temp = Console.ReadLine();
            //
 
            //The try-catch statement consists of a try block followed by one or more catch clauses, 
            // which specify handlers for different exceptions.
            try
            {
                j = Convert.ToInt32(temp);
                int k = i / j;
                Console.WriteLine("k = i / j");
                Console.WriteLine("Result k = {0}", k);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}