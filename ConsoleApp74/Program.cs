using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodHord
{
    class Program
    {
        static void Main(string[] args)
        {
            double x0 = 2;
            double x1 = 10;
            double e = 0.001;
            double x = method_chord(x0, x1, e);
            Console.WriteLine(x);
            Console.ReadLine();
        }

        public static double method_chord(double x_prev, double x_curr, double e)
        {
            double x_next = 0;
            double tmp;

            do
            {
                tmp = x_next;
                x_next = x_curr - f(x_curr) * (x_prev - x_curr) / (f(x_prev) - f(x_curr));
                x_prev = x_curr;
                x_curr = tmp;
            } while (Math.Abs(x_next - x_curr) > e);

            return x_next;
        }

        public static double f(double x)
        {
            return Math.Pow(x, 3) - 18 * x - 83;
        }
    }
}