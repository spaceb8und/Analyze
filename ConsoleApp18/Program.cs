using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Utils
{
    class Program
    {
 
        // A function that computes the factorial recursively
        public static int RecursiveFactorial(int a)
        {
            if (a < 0) throw new ArgumentException();
            if(a == 1)
            {
                return 1;
            }
            else
            {
                return a * RecursiveFactorial(a - 1);
            }           
        }
 
        // A function that calculates a factorial without recursion
        public static bool Factorial(int a, ref int answer)
        {
            if (a < 0) return false;
            for(int i=1; i-1 < a; i++)
            {
                answer *= i;
            }
            return true;
        }
 
        // A function that changes the values of two numbers
        public static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
 
        // A function that returns the maximum of two numbers
        public static int Greater(int a, int b)
        {
            if (a > b) return a;
            return b;
        }
        static void Main(string[] args)
        {
            // Block for calculating the largest of two numbers
            int x, y, greater;
            Test test;
            Console.WriteLine("Enter first number");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number");
            y = int.Parse(Console.ReadLine());
            test = new Test(x, y);
            test.greater = Greater(x, y);
            Console.WriteLine("Greater is {0}", test.greater);   
            // End block
 
            // Block swap
            Console.WriteLine("Before swap x = {0}, y = {1}", test.x, test.y);
            Swap(ref test.x,ref test.y);
            test.Print();
            // End block
 
            // Factorial Calculation Block
            Console.WriteLine("Enter number to run the method 'Factorial'");
            int number = int.Parse(Console.ReadLine());
            int answer = 1;
            if (!Factorial(number, ref answer))
            {
                throw new Exception();
            }
            Console.WriteLine("Factoral {0} = {1}", number, answer);
            // End block
 
            // Block for recursive factorial calculation
            Console.WriteLine("Enter number to run the method 'RecursiveFactorial'");
            number = int.Parse(Console.ReadLine());
            answer = RecursiveFactorial(number);
            Console.WriteLine("Factoral {0} = {1}", number, answer);
            // End block
            Console.ReadKey();
        }
    }
 
    public class Test
    {
        public int x;
        public int y;
        public int greater;
 
        public Test(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
 
        public void Print()
        {
            Console.WriteLine("{0}, {1}", x, y);
        }
       
 
    }
}
