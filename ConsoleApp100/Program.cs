using System;
using System.Data;

namespace ConsoleApp1 {
    class Program {

        class Compute {
            private static int Count = 0; //Счётчик созданных объектов класса
            public Compute () {
                Count++; //Увеличить счётчик на 1 при создании объекта
            }
            public double Exec (string expr) {
                return Convert.ToDouble (new DataTable ().Compute (expr, ""));
            }
            public static int GetCount () { return Count; } //Узнать значение счётчика
        }
        static void Main () {
            string [] Expressions = {
                "(5-2)%2 + 5./4",
                "-1+2/3",
                "1*2*3*error"
            };
            for (int i = 0; i < Expressions.Length; i++) {
                Compute Expr = new Compute (); //На самом деле, хватило бы статического метода в Compute
                try {
                    double d = Expr.Exec (Expressions [i]);
                    Console.WriteLine ("{0} = {1:F4}", Expressions [i], d);
                }
                catch (Exception e) {
                    Console.WriteLine ("Ошибочное выражение {0}: \"{1}\"", Expressions [i], e.Message);
                }
            }

            Console.WriteLine ("Всего обработано выражений: {0}", Compute.GetCount ());
            Console.ReadKey ();
        }
    }
}