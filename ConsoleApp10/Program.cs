using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    public abstract class Transport : IPrintable
    {
        private string name;
        private int weight;
        private int date;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Weight
        {
            get { return weight; }
            set
            {
                if (value > 0) weight = value;
                else throw new ArgumentException();
            }
        }

        public int Date
        {
            get { return date; }
            set { date = value; }
        }


        // Конструктор по умолчанию
        public Transport()
        {
            this.name = "None";
            this.weight = Int32.MaxValue;
            this.date = Int32.MaxValue;
        }

        // Конструктор с прямыми параметрами
        public Transport(string name, int weight, int date)
        {
            if (weight > 0 && date > 0)
            {
                this.name = name;
                this.weight = weight;
                this.date = date;
            }
            else
            {
                throw new ArgumentException("Invalid argument in constructor");
            }
        }

        public virtual void printInfo()
        {

            Console.WriteLine($"Name: {this.name}");
            Console.WriteLine($"Weight: {this.weight}");
            Console.WriteLine($"Year of release: {this.date}");
        }
    }

    public class Car : Transport
    {
        public Car() : base()
        {

        }

        public Car(string name, int weight, int date) : base(name, weight, date)
        {

        }

        public override void printInfo()
        {
            Console.WriteLine("Information about the car:");
            base.printInfo();
        }

    }

    public class Truck : Transport
    {
        public Truck() : base()
        {

        }

        public Truck(string name, int weight, int date) : base(name, weight, date)
        {

        }

        public override void printInfo()
        {
            Console.WriteLine("Information about the truck:");
            base.printInfo();
        }

    }

    public class Airplane : Transport
    {
        public Airplane() : base()
        {

        }

        public Airplane(string name, int weight, int date) : base(name, weight, date)
        {

        }

        public override void printInfo()
        {
            Console.WriteLine("Information about the airplane:");
            base.printInfo();
        }

    }

    public class Steamboat : Transport
    {
        public Steamboat() : base()
        {

        }

        public Steamboat(string name, int weight, int date) : base(name, weight, date)
        {

        }

        public override void printInfo()
        {
            Console.WriteLine("Information about the steamboat:");
            base.printInfo();
        }

    }




    interface IPrintable
    {
        void printInfo();
    }





    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Автомобиль", 800, 1990);
            car.printInfo();
            Airplane airplane = new Airplane("Самолет", 2000, 1922);
            airplane.printInfo();
            Steamboat steamboat = new Steamboat("Пароход", 10000, 1955);
            steamboat.printInfo();
            Truck truck = new Truck("Грузовик", 1000, 2000);
            truck.printInfo();
            Console.ReadKey();
        }
    }
}


