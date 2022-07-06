using System;

namespace ConsoleApp1 {
    class Factory {
        private int val;
        private Factory (int val = 0) { //Конструктор класса приватен
            this.val = ++val;
        }
        public static Factory makeFactory (int val = 0) { //Но есть фабрика объектов
            Factory factory = new Factory (val);
            return factory;
        }
        public override string ToString () { //переписываем встроенный метод
            return val.ToString ();
        }
    }

    class Program {
        static void Main (string[] args) {
            const int Size = 10;
            Factory [] Objects = new Factory [Size];
            //Объекты массива Factory пока пустые ссылки (null), то есть, конструктор по умолчанию
            //всё равно доступен. А вот new Factory (0) [Size] не сработало бы
            for (int i = 0; i < Size; i++) {
                Objects [i] = Factory.makeFactory (i);
                Console.WriteLine ("Объект номер {0}: {1}",i, Objects [i]);
            }
            Console.ReadKey ();
        }
    }
}