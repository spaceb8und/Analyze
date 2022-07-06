using System;
using System.Data;

namespace ConsoleApp1 {

    class MyDataTable {
        DataTable dt;
        DataRow dr;
        DataColumn dc;
        public MyDataTable (string TableName, string [] ColumnNames, Type [] ColumnTypes) {
            dt = new DataTable ();
            dt.TableName = TableName;
            for (int i = 0; i < ColumnNames.Length; i++) dt.Columns.Add (ColumnNames [i], ColumnTypes [i]);
        }
        public DataRow CreateRow () { //Создать строку
            dr = dt.NewRow (); 
            return dr;
        }
        public void Add (DataRow dr) { //Добавить строку в базу
            dt.Rows.Add (dr); 
        }
        public DataColumn CreateColumn (string Name, Type type, string expr) { //Создать вычисляемый столбец
            dc = new DataColumn ();
            dc.ColumnName = Name;
            dc.DataType = type;
            dc.Expression = expr;
            dt.Columns.Add (dc);
            return dc;
        }
        public void AddRow (DataRow dr) { //Добавить строку в базу
            dt.Rows.Add (dr);
        }

        public string Exec (string expr) {
            return Convert.ToString (dt.Compute (expr, ""));
        }
    }

    class Program {
        static void Main () {
            string [] ColumnNames = { "Имя", "Оплата", "Комиссия"};
            Type [] ColumnTypes = { typeof (string), typeof (int), typeof (double) };
            MyDataTable Formula = new MyDataTable ("Таблица", ColumnNames, ColumnTypes);
            //Создали таблицу
            DataRow dr = Formula.CreateRow ();
            dr ["Имя"] = "Вася";
            dr ["Оплата"] = 30000;
            dr ["Комиссия"] = 0.15;
            Formula.AddRow (dr);
            dr = Formula.CreateRow ();
            dr ["Имя"] = "Петя";
            dr ["Оплата"] = 40000;
            dr ["Комиссия"] = 0.20;
            Formula.AddRow (dr);
            //Добавили данные в строки
            Console.WriteLine ("Avg(Оплата) = " + Formula.Exec ("Avg(Оплата)"));
            //Посчитали по формуле
            DataColumn dc = Formula.CreateColumn ("Итого", typeof (double), "Оплата - Оплата * Комиссия");
            Console.WriteLine ("Sum(Итого) = " + Formula.Exec ("Sum(Итого)"));
            //Посчитали выражение над добавленным столбцом
            //(30000-30000*0.15)+(40000-40000*0.20)

            Console.ReadKey ();
        }
    }
}