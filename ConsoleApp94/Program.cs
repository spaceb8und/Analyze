using System;

namespace ConsoleApp1 {

    class Program {
        static void Swap <T> (ref T lhs, ref T rhs) { //Аргументы получены по ссылке
            T temp = lhs;   lhs = rhs;   rhs = temp;
        }

        static void GetNumberParts (double n, out double whole, out double frac) {
            //Второй и третий аргументы будут возвращены по ссылке
            whole = Math.Floor(n);
            frac = n - whole;
        }

        static double Summa (params double [] nums) { //Функция может иметь переменное число аргументов
            double sum = 0;
            for (int i = 0; i < nums.Length; i++) sum += nums [i];
            return sum;
        }

        static void Main (string[] args) {
   
            double a = 1.5;
            double b = 2.7;
            Swap (ref a, ref b); //Аргументы переданы по ссылке
            Console.WriteLine (a + " " + b);

            double d, f;
            GetNumberParts (a, out d, out f); //Второй и третий аргументы будут возвращены по ссылке
            Console.WriteLine ("Целая часть числа равна " + d);
            Console.WriteLine ("Дробная часть числа равна " + f);

            double s = Summa (1, 2, 3, 4);
            Console.WriteLine ("1+2+3+4= " + s);

            Console.ReadKey ();
        }
    }
}