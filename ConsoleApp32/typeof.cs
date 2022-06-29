using System;
using static System.Console;
using System.Linq;
using System.Reflection;

namespace ConsoleApp2
{
    public class Test
    {
        public Type ThisType { get; set; }
        public Test(Type type)
        {
            ThisType = type;
        }

        public virtual string ToString()
        {
            return $"Тип {ThisType.Name}";
        }
    }
    public class TypeClass : Test
    {
        public TypeClass() : base(typeof(TypeClass))
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TypeClass t = new TypeClass();
            WriteLine(t.ToString());
        }
    }
}