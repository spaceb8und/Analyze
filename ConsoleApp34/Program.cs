using System;
using System.Globalization;

namespace Operation
{
    class Program
    {
        static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

        class Number
        {
            readonly int _number;

            public Number(int number) { _number = number; }

            public override string ToString() { return _number.ToString(_ifp); }
            
            /// <summary>
            /// Перегрузка оператора сложение.
            /// Складывает объект типа Number и число, описанное типом string.
            /// </summary>
            /// <param name="currenNumber">Number</param>
            /// <param name="otherNumber">string</param>
            /// <returns>Результат - сумма чисел, представленная типом string</returns>
            public static string operator +(Number currenNumber, string otherNumber) {
                string result = (currenNumber._number + int.Parse(otherNumber)).ToString();
                return result;
            }
        }

        static void Main(string[] args) {
            int someValue1 = 10;
            int someValue2 = 5;
            
            // Изначальный код совершает конкатенацию
            string result = new Number(someValue1) + someValue2.ToString(_ifp);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}