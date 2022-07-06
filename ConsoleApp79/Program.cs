using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fibo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Какой член ряда Фибоначчи Вы хотите увидеть?");
            int number = Convert.ToInt32(Console.ReadLine());
            if (number > 48)
            {
                Console.WriteLine("Извините, программа способна высчитывать только до 48 члена ряда Фибоначчи.");
                
            }
            else if (number < 1)
            {
                Console.WriteLine("В ряде Фибоначчи нет такого элемента.");
            }
            else
            {
                int perv = 1;
                int vtor = 1;
                int sum = 0;

                int j = 2;
                while (j <= number)
                {
                    sum = perv + vtor;
                    perv = vtor;
                    vtor = sum;
                    j++;
                }
                Console.WriteLine("Под номером " + number + " в ряде Фибоначчи стоит число " + perv); 
            }
            Console.ReadLine();
        }
    }
}