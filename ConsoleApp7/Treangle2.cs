using System;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Matrix
    {
        static void Main(string[] args)
        {
            bool _IsValid = false;
            int n=0, m=0, l=0, k=0;

            while (!_IsValid)
            {
                Console.WriteLine("Введите размерность первой матрицы:");
                var data = Console.ReadLine().Split(' ');
                n = Int32.Parse(data[0]);
                m = Int32.Parse(data[1]);
                Console.WriteLine("Введите размерность второй матрицы:");
                data = Console.ReadLine().Split(' ');
                l = Int32.Parse(data[0]);
                k = Int32.Parse(data[1]);
                if (m != l)
                {
                    Console.WriteLine("Перемножить матрицы невозможно.");
                    continue;
                }
                _IsValid = true;
            }
            
            int[,] a = new int[n, m];
            int[,] b = new int[l, k];

            Random rand = new Random();
            
            Console.WriteLine("Первая матрица:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rand.Next(15);
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
            
            Console.WriteLine("Вторая матрица:");
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    b[i, j] = rand.Next(15);
                    Console.Write(b[i, j] + " ");
                }
                Console.WriteLine();
            }

                int[,] c = new int[n, k];

            Parallel.For(0, n, i =>
            {
                for (int j = 0; j < k; j++)
                {
                    for (int z = 0; z < m; z++)
                    {
                        c[i, j] += a[i,z] * b[z, j];
                    }
                }
            });
            Console.WriteLine("Результат:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    Console.Write(c[i,j] + " ");
                }
                Console.WriteLine();
            }

        } 
    }
    
}
