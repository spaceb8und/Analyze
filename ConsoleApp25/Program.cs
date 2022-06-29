using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTest
{
    class Test
    {
        static void Main()
        {
            int i = 0;
            ulong ul = 0;
            string s = "Test";
            Console.WriteLine(
                "IsItFormattable(int) = {0}, IsItFormattable(ulong), = {1}, IsItFormattable(string) = {2}",
                Utils.IsItFormattable(i), Utils.IsItFormattable(ul),
                Utils.IsItFormattable(s)); // Output of the IsItFormattable function values
            Console.ReadKey();
        }
    }





    class Utils
    {

        /// Is it possible to format a value into a string representation
        public static bool IsItFormattable(object x)
        {
            return x is IFormattable;
        }

        /// Return reversed string
        public static string Reverse(string s)
        {
            string sRev = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                sRev += s[i];
            }

            return sRev;
        }

        //
        // Return the larger of two integer values
        //

        public static int Greater(int a, int b)
        {
            if (a > b)
                return a;
            else
                return b;

            // Alternative version - more terse
            // return (a>b) > (a) : (b);
        }

        //
        // Swap two integers, passed by reference
        //

        public static void Swap(ref int a, ref int b)
        {
            int temp;
            temp = a;
            a = b;
            b = temp;
        }

        //
        // Calculate factorial
        // and return the result as an out parameter
        //

        public static bool Factorial(int n, out int answer)
        {
            int k; // loop counter
            int f; // working value
            bool ok = true; // true if ok, false if not

            // Check the input value

            if (n < 0)
                ok = false;

            // Calculate the factorial value as the
            // product of all the numbers from 2 to n

            try
            {
                checked
                {
                    f = 1;
                    for (k = 2; k <= n; ++k)
                    {
                        f = f * k;
                    }

                    // Here is a terse alternative
                    // for (f=1,k=2;k<=n;++k)
                    //     f*=k;

                }
            }
            catch (Exception)
            {
                // If something goes wrong in the calculation,
                // catch it here. All exceptions
                // are handled the same way: set the result to
                // to zero and return false.

                f = 0;
                ok = false;
            }

            // assign result value                
            answer = f;

            // return to caller
            return ok;
        }

        //
        // Another way to solve the factorial problem, this time
        // as a recursive function
        //

        public static bool RecursiveFactorial(int n, out int f)
        {
            bool ok = true;

            // Trap negative inputs
            if (n < 0)
            {
                f = 0;
                ok = false;
            }

            if (n <= 1)
                f = 1;
            else
            {
                try
                {
                    int pf;
                    checked
                    {
                        ok = RecursiveFactorial(n - 1, out pf);
                        f = n * pf;
                    }
                }
                catch (Exception)
                {
                    // Something went wrong. Set error
                    // flag and return zero.
                    f = 0;
                    ok = false;
                }

            }

            return ok;
        }
    }
}

