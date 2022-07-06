using System;

namespace ConsoleApp1 {

    class BoxingDemo {
        int x;
        BoxingDemo (int x = 0) { this.x = x;  } //Конструктор
        public override string ToString () { return x.ToString (); }
        //Переопределение метода ToString класса object
        public static int Sqr (object о) { //Метод для возведения в квадрат с параметром типа object
            return (int) о * (int) о;
        }
    }

    class Program { //Главный класс Program
        static int Main () {
            int x = 10;
            Console.WriteLine ("x = " + x);
            x = BoxingDemo.Sqr (x);
            // значение x автоматически упаковывается, когда оно передается методу Sqr()
            Console.WriteLine ("x^2 = " + x);

            object obj = x; // упаковать значение переменной х в объект
            int y = (int) obj; 
            // распаковать значение из объекта, доступного по ссылке obj, в переменную типа int
            Console.WriteLine ("y = " + y);

            object [] arr = new object [3]; //массив из разнотипных значений
            arr [0] = x;
            arr [1] = (double) x + 0.5;
            arr [2] = "Привет";
            for (int i = 0; i < arr.Length; i++) {
                var item = arr [i];
                var type = item.GetType ();
                Console.WriteLine ($"arr[{i}] = {item} ({type})");
            }
    
            Console.ReadKey ();
            return 0;
        }
    } //Program

} //namespace