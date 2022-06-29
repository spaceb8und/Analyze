using System.Diagnostics;

namespace Integral
{
    public class Calc
    {
        public TaskFactory Factory { get; set; }
        public Calc()
        {
            Factory = new TaskFactory();
        }

        public double integralFunction(double x)
        {
            return Math.Sqrt(x);
        }

        public double RunTask(double start, double h, double e)
        {
            var x = start;
            var val = h * integralFunction(x);
            if (h <= e) return val;
            return Factory.StartNew(() => FindIntegral(x, x + h, e)).Result;
        }
        public double FindIntegral(double start, double end, double e)
        {
            double res = 0;
            double h = (end - start) / 2;
            res += Factory.StartNew(() => RunTask(start, h, e)).Result;
            res += Factory.StartNew(() => RunTask(start + h, h, e)).Result;
            return res;
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calc();
            var timerAsync = new Stopwatch();
            timerAsync.Start();
            var t = Task.Run(() => calc.FindIntegral(0, 4, 0.00001)).ContinueWith((e) =>
            {
                Console.WriteLine(e.Result);
                timerAsync.Stop();
                var time = timerAsync.Elapsed;
                Console.WriteLine("Parallel time needed: " + time.TotalMilliseconds);
            });
            Task.WaitAll(t);
            double res = 0;
            var timerSync = new Stopwatch();
            timerSync.Start();
            for (double i = 0; i < 4; i += 0.00001 )
            {
                res += 0.00001 * Math.Sqrt(i);
            }
            
            timerSync.Stop();
            var time = timerSync.Elapsed;
            Console.WriteLine(res);
            Console.WriteLine("Sync time needed: " + time.TotalMilliseconds);
        }
        
    }
}