using System;

namespace ConsoleApp1 {
    class Program {
        static void PrintMatrix(int [,] a) {
            for (int i = 0; i < a.GetLength(0); i++) {
                for (int j = 0; j < a.GetLength(1); j++) {
                    Console.Write ("{0:F4} ",a[i,j]);
                }
                Console.WriteLine ();
            }
        }
        static void PrintJaggedMatrix (int [][] a) {
            for (int i = 0; i < a.Length; i++) {
                for (int j = 0; j < a[i].Length; j++) {
                    Console.Write ("{0:F4} ", a[i][j]);
                }
                Console.WriteLine ();
            }
        }
        static void Main (string[] args) {

            //"Паскалеподобная" матрица, количество элементов в каждой строке одинаково
            int [,] matrix = {
                {1,2,3 },
                {4,5,6 }
            };
            PrintMatrix (matrix);

            //"Си-подобная" матрица, количество элементов в каждой строке может быть различным
            const int jaggedMarixRows = 3;
            int [] [] jaggedMarix = new int [jaggedMarixRows] [];
            for (int i = 0, k = 1; i < jaggedMarix.Length; i++) { 
                try {
                    jaggedMarix [i] = new int [i + 1];
                }
                catch (OutOfMemoryException e) {
                    Console.WriteLine ("Memory allocation failed \"{0:C}\" in string {0:D}\n",e,i);
                    break;
                }
                for (int j = 0; j < jaggedMarix[i].Length; j++) jaggedMarix [i] [j] = k++;
            }
            PrintJaggedMatrix (jaggedMarix);

            Console.ReadKey ();
        }
    }
}