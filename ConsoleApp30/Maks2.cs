using System;

namespace whatDoing2
{
    class Program
    {
        public class Student : Child
        {
            public Student(string fullname, int age, string school) : base(fullname, age) {
                School = school;
            }
            protected Student(string fullname, int age) : base(fullname, age) {}
        
            public override string Name {
                get
                {
                    return $"Моё имя {firstName} {lastName}, место учёбы: {School}";
                }
                protected set { base.Name = value; }
            }
        
            // Собственное свойство
            public string School {
                get;
                set;
            }

            public override void Eat() {
                Console.WriteLine("Я хожу в KFC каждый день.");
            }

            public override int Age {
                get
                {
                    return age;
                }
                set
                {
                    if (value is > 7 and < 25) {
                        age = value;
                    }
                }
            }
        
            // Собственный метод
            public void DoHomeWork() {
                Console.WriteLine("Сейчас я делаю домашнюю работу.");
            }
        }
        public abstract class Person
        {
            protected string firstName;
            protected string lastName;
        
            // Абстрактное свойство
            public abstract string Name {
                get;
                protected set;
            }
        
            // Обычное поле с виртуальным свойством
            protected int age;
            public virtual int Age {
                get => age;
                set
                {
                    if (value is > -1 and < 120) {
                        age = value;
                    }
                }
            }
        
            // Абстрактный метод, без реализации
            public abstract void Eat();
        
            // Обычный метод
            public string GoWalk() {
                return "Я гуляю!";
            }
        }
        public class Intern : Student
    {
        private string internship;
        public Intern(string fullname, int age, string internship) : base(fullname, age) {
            Internship = internship;
        }
        protected Intern(string fullname, int age) : base(fullname, age) {}
        
        // Собственное свойство - место стажировки
        public string Internship {
            get
            {
                return $"Моё место стажировки: {internship}";
            }
            set
            {
                if (!value.Equals("")) {
                    internship = value;
                }
            }
        }

        public override string Name {
            get
            {
                return $"Моё имя {firstName} {lastName}, мне {Age}. {Internship}";
            }
            protected set
            {
                base.Name = value;
            }
        }

        public override int Age {
            get
            {
                return age;
            }
            set
            {
                if (value is > 24 and < 33) {
                    age = value;
                }
            }
        }

        public override void Eat() {
            Console.WriteLine("Я пью кофе по утрам.");
        }
        
        // Собственный метод - спать
        public void Sleep() {
            Console.WriteLine("Я сплю везде, где только смогу, потому что не высыпаюсь!");
            int r = new Random().Next(0, 4);
            switch (r) {
                case 1: {
                    Console.WriteLine("Сейчас я сплю дома в кровати.");
                    break;
                }
                case 2: {
                    Console.WriteLine("Сейчас я сплю на кухне.");
                    break;
                }
                case 3: {
                    Console.WriteLine("Сейчас я сплю в метро.");
                    break;
                }
                case 4: {
                    Console.WriteLine("Сейчас я сплю в месте прохождения стажировки.");
                    break;
                }
                default: {
                    Console.WriteLine("Сейчас я сплю под мостом в коробке");
                    break;
                }
            }
        }
    }
        public sealed class Employee : Intern
        {
            private string job;
            public Employee(string fullname, int age, string job) : base(fullname, age) {
                Job = job;
            }
        
            // Собственное свойство - работа
            public string Job {
                get
                {
                    if (job.Equals("безработный")) {
                        return "Я пока что безработный";
                    }

                    return $"Моё место работы: {job}";
                }
                set
                {
                    if (value.Equals("")) {
                        job = "безработный";
                    }
                    else {
                        job = value;
                    }
                }
            }

            public override int Age {
                get
                {
                    return age;
                }
                set
                {
                    if (value is > 32 and < 120) {
                        age = value;
                    }
                }
            }

            public override string Name {
                get
                {
                    return $"Моё имя {firstName} {lastName}, мне {Age}. {Job}";
                }
                protected set
                {
                    base.Name = value;
                }
            }

            public override void Eat() {
                Console.WriteLine("Я пытаюсь питаться правильно. 5-разовое питание, диетическая пища.");
            }
        
            // Собственный метод - получить зарплату
            public void GetSalary(int money) {
                Console.WriteLine($"Ура! Я получил зарплату! Она составляет {money} р. в месяц.");
            }
        }
        public class Child : Person
    {
        public Child(string fullname, int age) {
            if (!fullname.Equals("")) {
                Name = fullname;
                Age = age;
            }
        }
        
        // Даём реализацию абстрактному свойству
        public override string Name {
            get
            {
                return $"Моё имя {firstName} {lastName}, мой возраст: {age}, приятно познакомиться! \n" + Friends;
            }
            protected set
            {
                string[] fullname = value.Split(" ");
                firstName = fullname[0];
                lastName = fullname[1];
            }
        }

        private int friends;
        public string Friends {
            get
            {
                string ending = "";
                if (friends is > 9 and < 20) {
                    ending = "друзей!";
                }
                else {
                    switch (friends % 10) {
                        case 0 or 5 or 6 or 7 or 8 or 9: {
                            if (friends == 0) {
                                ending = "пока нет друзей(((";
                                break;
                            }

                            ending = "друзей!";
                            break;
                        }
                        case 1: {
                            ending = "друг!";
                            break;
                        }
                        case 2 or 3 or 4: {
                            ending = "друга!";
                            break;
                        }
                    }
                }

                if (friends == 0) {
                    return $"У меня {ending}";
                }
                return $"У меня {friends} {ending}";
            }
        }
        
        // Собственный метод добавления друзей
        public void AddFriends(int friends) {
            this.friends += friends;
        }
        
        // Ребёнок ест свою еду каждое утро
        public override void Eat() {
            Console.WriteLine("Я ем овсяную кашу каждое утро!");
        }
        
        // Переопределяем возраст ребёнка (допустим, до 8 лет - это ребёнок)
        public override int Age {
            get { return age; }
            set
            {
                if (value is > -1 and < 8) {
                    age = value;
                }
            }
        }
        
        // Собственный метод - поход в детский сад
        public void GoToKindergarten() {
            if (friends == 0) {
                Console.WriteLine("Я хожу в детский сад! Там я пытаюсь найти себе друзей.");
                return;
            } else if (friends == 1) {
                Console.WriteLine("Я хожу в детский сад! Там я играю со своим лучшим другом.");
                return;
            }
            Console.WriteLine("Я хожу в детский сад! Там я встречаюсь со своими друзьями.");
        }
    }
        static void Main(string[] args) {
            Person child = new Child("Петя Петров", 5); // Полиморфизм
            Console.WriteLine(child.Name);
            child.GoWalk();

            // Демонстрация методов Child
            Child othercChildhild = new Child("Ваня Иванов", 4);
            othercChildhild.AddFriends(new Random().Next(30));
            Console.Write('\n' + othercChildhild.Name + " ");
            othercChildhild.GoToKindergarten();
            othercChildhild.Eat();
            Console.Write(othercChildhild.GoWalk() + '\n');
            
            // Демонстрация методов Student
            Student student = new Student("Николай Николаев", 20, "Российский университет транспорта");
            Console.WriteLine('\n' + student.Name);
            student.Eat();
            student.DoHomeWork();
            student.GoWalk();
            
            // Демонстрация методов Intern
            Intern intern = new Intern("Максим Максимов", 27, "Yandex");
            Console.WriteLine('\n' + intern.Name);
            intern.Eat();
            intern.Sleep();
            
            // Демонстрация методов Employee
            Employee employee = new Employee("Анатолий Анатольев", 42, "Mail.ru Group");
            Console.WriteLine('\n' + employee.Name);
            employee.Eat();
            employee.GetSalary(120000);

            // Person em_2 = new Employee("Анатолий Анатольев", 42, "Mail.ru Group");
            // Console.WriteLine('\n' + em_2.Name);
        }
    }
}