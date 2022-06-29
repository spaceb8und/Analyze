using System;
using System.Collections.Generic;
using System.Threading;

namespace multithread_monitoring
{
    class PoolThreads
    {
        private List<Thread> array;

        public PoolThreads(int n) {
            array = new List<Thread>();
            for (int i = 0; i < n; i++) {
                Thread t = new Thread(new ParameterizedThreadStart(Do));
                t.Name = "MyThread" + i;
                array.Add(t);
            }
        }

        public static void Do(Object s) {
            Console.WriteLine($"MyThread-{s} started...", (int)s);
            Thread.Sleep(new Random().Next(50000));
            Console.WriteLine($"MeThread-{s} finished...", (int)s);
        }

        public void StartAll() {
            int i = 0;
            foreach (Thread thread in array) {
                thread.Start(i++);
            }
        }
    }
    internal class Program
    {
        public static void Main(string[] args) {
            PoolThreads poolThreads = new PoolThreads(int.Parse(Console.ReadLine() ?? string.Empty));
            poolThreads.StartAll();
        }
    }
}