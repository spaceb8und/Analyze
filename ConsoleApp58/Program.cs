using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix
    {
        public int[,] elements { get; set; }
        public TaskFactory Factory = new TaskFactory();
        public int rows { get; set; }
        public int cols { get; set; }
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            elements = new int[rows, cols];
        }

        public void InitializeWithRand()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    elements[i, j] = new Random().Next(1, 9);
                }
            }
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(elements[i,j] + "  ");
                }
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public Matrix SyncMultiplyBy(Matrix b)
        {
            var timer = new Stopwatch();
            timer.Start();
            Matrix res = new Matrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var sum = 0;
                    for (int k = 0; k < cols; k++)
                    {
                        sum += elements[i, k] * b.elements[k, j];
                    }
                    res.elements[i, j] = sum;
                }
            }
            timer.Stop();
            var time = timer.Elapsed;
            Console.WriteLine("Однопоточный метод - " + time.TotalMilliseconds);
            return res;
        }

        public Matrix ParallelMultiplyBy(Matrix b)
        {
            var timer = new Stopwatch();
            timer.Start();
            Matrix res = new Matrix(rows, cols);
            List<Task> tasks = new List<Task>(); 
            for (int i = 0; i < rows; i++)
            {
                var ind = i;
                tasks.Add(Factory.StartNew(() =>
                {
                    int rowId = ind;
                    for (int j = 0; j < cols; j++)
                    {
                        var sum = 0;
                        for (int k = 0; k < cols; k++)
                        {
                            sum += elements[rowId, k] * b.elements[k, j];
                        }

                        res.elements[rowId, j] = sum;
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray());
            timer.Stop();
            var time = timer.Elapsed;
            Console.WriteLine("Многопоточный метод (строки) - " + time.TotalMilliseconds);
            return res;
        }
        public Matrix ParallelByCellMultiplyBy(Matrix b)
        {
            var timer = new Stopwatch();
            timer.Start();
            Matrix res = new Matrix(rows, cols);
            List<Task> tasks = new List<Task>(); 
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var row = i;
                    var col = j;
                    tasks.Add(Factory.StartNew(() =>
                    {
                        var sum = 0;
                        for (int k = 0; k < cols; k++)
                        {
                            sum += elements[row, k] * b.elements[k, col];
                        }

                        res.elements[row,col] = sum;
                    }));
                    
                }
            }
            Task.WaitAll(tasks.ToArray());
            timer.Stop();
            var time = timer.Elapsed;
            Console.WriteLine("Многопоточный метод (ячейки) - " + time.TotalMilliseconds);
            return res;
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность матриц");
            var size = Convert.ToInt32(Console.ReadLine());
            var a = new Matrix(size, size);
            a.InitializeWithRand();
            var b = new Matrix(size, size);
            b.InitializeWithRand();
            a.ParallelMultiplyBy(b);
            a.ParallelByCellMultiplyBy(b);
            a.SyncMultiplyBy(b);
        }
    }
}

