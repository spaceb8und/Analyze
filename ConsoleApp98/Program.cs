using System;

namespace ConsoleApp1 {
    class A {
        private string str;
        private double val;
        public A(string str="", double val = 0) { this.str = str;  this.val = val; }
        public string view() {
            return str + ", " + val.ToString(); 
        }
    }
    class Program {
        static void Main (string[] args) {
            string name = "Паоло Гудини";
            A a = new A(name,1);
            Console.WriteLine (a.view());
            Console.ReadKey();
        }
    }
}