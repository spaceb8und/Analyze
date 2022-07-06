using System;
using System.Globalization;

namespace ConsoleApp1 {
    internal class Program {
        private static void Main () {
   
            //Способ 1: Parse 
            Int32 val1 = Int32.Parse ("100"); //100
            //простое преобразование
            Int32 val2 = Int32.Parse ("(200)", NumberStyles.AllowParentheses); //-200
            //перегрузка с указанием стиля
            int val3 = int.Parse ("30,000", NumberStyles.AllowThousands, new CultureInfo ("en-au")); //30000
            //перегрузка с указанием стиля и культуры
            Console.WriteLine ($"{val1} {val2} {val3}");

            //Способ 2: Convert
            val1 = Convert.ToInt32 ("123456"); //123456
            val2 = Convert.ToInt32 ("10000",2); //16
            val3 = Convert.ToInt32 ("100", 16); //256
            Console.WriteLine ($"{val1} {val2} {val3}");

            //Способ 3: TryParse 
            string numberStr = "123456";
            int number;
            bool isParsable = Int32.TryParse (numberStr, out number); //123456
            if (isParsable) Console.WriteLine (number);
            else Console.WriteLine ("Неверный формат: "+ numberStr);
            numberStr = "123,45";
            double val;
            isParsable = double.TryParse (numberStr, NumberStyles.Float, NumberFormatInfo.CurrentInfo, out val);
            //val будет равно 123,45 , если локаль русская
            if (isParsable) Console.WriteLine (val);
            else Console.WriteLine ("Неверный формат: "+ numberStr);

            //Обработка исключений при преобразованиях 1 и 2:
            string str1 = "100f";
            try {
                val1 = Int32.Parse (str1);
                Console.WriteLine (val1);
            }
            catch (Exception e) {
                Console.WriteLine ("Неверный формат Parse: " + str1);
            }
            try {
                val1 = Convert.ToInt32 (str1);
                Console.WriteLine (val1);
            }
            catch (Exception e) {
                Console.WriteLine ("Неверный формат ToInt32: " + str1);
            }
   
            Console.ReadKey ();
        }

    }
}