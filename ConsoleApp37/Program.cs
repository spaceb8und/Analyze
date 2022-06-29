using System;
using System.IO;

namespace AnElephantOutOfFly
{
    class Program
    {
        static void Main(string[] args) {
            TransformToElephant();
            Console.WriteLine("Муха");
            //... custom application code
        }

        static void TransformToElephant() {
            //... write your code here
            // https://docs.microsoft.com/ru-ru/dotnet/api/system.appdomain?view=netframework-4.8
            // https://docs.microsoft.com/ru-ru/dotnet/api/system.console.setout?view=netframework-4.8
            if (AppDomain.CurrentDomain.GetData("Слон") == null)
            {
                Console.WriteLine("Слон");
                Console.SetOut(new StringWriter());
                AppDomain.CurrentDomain.SetData("Слон", "");
                Main(Array.Empty<string>());
            }
        }
    }
}