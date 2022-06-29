using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Matrix
{
    class MatrixMultiply
    {
 
        public static void Mul(int[,] lhs, int[,] rhs, ref int[,] result)
        {
            result[0, 0] = lhs[0, 0] * rhs[0, 0] + lhs[0, 1] * rhs[1, 0];
            result[0, 1] = lhs[0, 0] * rhs[0, 1] + lhs[0, 1] * rhs[1, 1];
            result[1, 0] = lhs[1, 0] * rhs[0, 0] + lhs[1, 1] * rhs[1, 0];
            result[1, 1] = lhs[1, 0] * rhs[0, 1] + lhs[1, 1] * rhs[1, 1];
 
            // output result mul
            Console.WriteLine("The result of multiplying the first array by the second:");
            for (uint i = 0; i < 2; i++)
            {
                for (uint j = 0; j < 2; j++)
                {
 
                    Console.Write($"{result[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int[,] a = new int[2, 2]; // first matrix
            int[,] b = new int[2, 2]; // second matrix
            int[,] result = new int[2, 2];
            Console.WriteLine("Enter the firts massive 2x2:");
            // input first matrix
            for(uint i = 0; i < 2; i++)
            {
                for(uint j = 0; j < 2; j++)
                {
 
                    a[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }
 
            // input second matrix
            Console.WriteLine("Enter the second massive 2x2:");
            for (uint i = 0; i < 2; i++)
            {
                for (uint j = 0; j < 2; j++)
                {
 
                    b[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Mul(a, b, ref result); // a mul b
            Console.ReadKey();
        }
    }
}