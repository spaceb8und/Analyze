using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

namespace BreakMeDown
{
    class Program
    {
        static void Main(string[] args) {
            try {
                FailProcess();
            }
            catch {
            }

            Console.WriteLine("Failed to fail process!");
            Console.ReadKey();
        }

        static void FailProcess() {
            //... write your code here
            // Process.GetCurrentProcess().Kill(); // System.Diagnostics.Process
            // Environment.Exit(0); // Указываем код ошибки при завершении.
        }
    }
}