using System;

namespace LR_2_3
{
    class Employee
    {
       
        private string name;
        private Vacancies vacancy;
        private int salary;
        private int[] hiredate=new int[3];
        public Employee()
        {
            this.name = "";
            this.vacancy = 0;
            this.salary = 0;
            this.hiredate[0]=0;
            this.hiredate[1]=0;
            this.hiredate[2]=0;

        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public Vacancies Vacancy
        {
            get
            {
                return vacancy;
            }

            set
            {
                vacancy = value;
            }
        }
        public int Salary
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }
        public int[] Hiredate
        {
            get
            {
                return  hiredate;
            }

            set
            {
                hiredate = value;
            }
        }
    

    }
    public enum Vacancies
    {
        Manager = 1,
        Boss,
        Clerk,
        Salesman
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("|Лабораторная работа №3; Выполнил студент гр. 6115 Трофимов Михаил Владимирович|");
            string name;
            Vacancies vacancy;
            Console.WriteLine("Введите количество сотрудников");
             int n;
            int n_Vacancy;
            int salary;
            int[] date=new int[3];    
             n = Convert.ToInt32(Console.ReadLine());
            Employee[] emp = new Employee[n];
            bool boss_key = false;

            for (int i = 0; i < n; i++)
            {
                Console.Clear();
                 emp[i] = new Employee();
                Console.WriteLine("Введите имя сотрудника номер "+ (i+1));
                name = Console.ReadLine();
                emp[i].Name = name;
                Console.WriteLine("1-manager , 2-boss, 3- clerk, 4-salesman");
                n_Vacancy= Convert.ToInt32(Console.ReadLine());
                if (boss_key == false)
                {
                    if (n_Vacancy > 0 && n_Vacancy < 5)
                    {
                        if (n_Vacancy == 1)
                        {
                            vacancy = Vacancies.Manager;
                            emp[i].Vacancy = vacancy;
                        }
                        if (n_Vacancy == 2)
                        {
                            vacancy = Vacancies.Boss;
                            emp[i].Vacancy = vacancy;
                        }
                        if (n_Vacancy == 3)
                        {
                            vacancy = Vacancies.Clerk;
                            emp[i].Vacancy = vacancy;
                        }
                        if (n_Vacancy == 4)
                        {
                            vacancy = Vacancies.Salesman;
                            emp[i].Vacancy = vacancy;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы можете выбрать только одну из 4 цифр вакансий");
                    }

                    Console.WriteLine("Введите Зарплату");
                    salary = Convert.ToInt32(Console.ReadLine());
                    if (salary >= 0)
                    {
                        emp[i].Salary = salary;
                    }
                    Console.WriteLine("Введите День приема ");
                    date[0] = Convert.ToInt32(Console.ReadLine());
                    if (date[0] > 0 && date[0] < 32)
                    {
                        emp[i].Hiredate[0] = date[0];
                        Console.WriteLine("Введите месяц приема");
                        date[1] = Convert.ToInt32(Console.ReadLine());
                        if (date[1] > 0 && date[1] < 13)
                        {
                            emp[i].Hiredate[1] = date[1];
                            Console.WriteLine("Введите год приема  ");
                            date[2] = Convert.ToInt32(Console.ReadLine());
                            if (date[2] > 0 && date[2] < 2021)
                            {
                                emp[i].Hiredate[2] = date[2];
                            }
                            else
                            {
                                Console.WriteLine("Такой даты не существует: Сотрудник не принят");
                                Console.WriteLine("Введите этого сотрудника заново");
                                Console.ReadKey();
                                if (i != 0)
                                {
                                    i = i - 2;
                                }
                                else i = -1;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Такой даты не существует: Сотрудник не принят");
                            Console.WriteLine("Введите этого сотрудника заново");
                            Console.ReadKey();
                            if (i != 0)
                            {
                                i = i - 2;
                            }
                            else i = -1;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такой даты не существует: Сотрудник не принят");
                        Console.WriteLine("Введите этого сотрудника заново");
                        Console.ReadKey();
                        if (i != 0)
                        {
                            i = i - 2;
                        }
                        else i = -1;
                    }
                }
                else
                {
                    Console.WriteLine("Босс уже существует");
                    Console.WriteLine("Введите этого сотрудника заново");
                    Console.ReadKey();
                    if (i != 0)
                    {
                        i = i - 2;
                    }
                    else i = -1;

                }
                

            }


            Console.Clear();
            for (int i = 0; i < n; i++)
            {
                if (emp[i].Hiredate[1] > 0 && emp[i].Hiredate[1] < 10)
                {
                    Console.WriteLine(i + 1 + ": " + "  Имя: " + emp[i].Name + "  Вакансия: " + emp[i].Vacancy + "  Зарплата:" + emp[i].Salary + "  Дата:" + emp[i].Hiredate[0] + "." +"0"+ emp[i].Hiredate[1] + "." + emp[i].Hiredate[2]);
                }
                else
                {
                    Console.WriteLine(i + 1 + ": " + "  Имя: " + emp[i].Name + "  Вакансия: " + emp[i].Vacancy + "  Зарплата:" + emp[i].Salary + "  Дата:" + emp[i].Hiredate[0] + "." + emp[i].Hiredate[1] + "." + emp[i].Hiredate[2]);
                }
             }
            Console.ReadKey();

            string menu;
            bool key = true;
            do
            {
                Console.Clear();
                Console.WriteLine("|Лабораторная работа №3; Выполнил студент гр. 6115 Трофимов Михаил Владимирович                           |");
                Console.WriteLine("|=========================================================================================================|");
                Console.WriteLine("|Вывести полную информацию о сотрудниках - '1'                                                            |");
                Console.WriteLine("|Вывести полную информацию о сотрудниках, работающих в указанной должности - '2'                          |");
                Console.WriteLine("|Вывести в алфавитном порядке всех менеджеров, зарплата которых больше средней зарплаты всех клерков - '3'|");
                Console.WriteLine("|Вывести в алфавитном порядке всех сотрудников, принятых на работу позже босса - '4'                      |");
                Console.WriteLine("|Выход из программы  - '0'                                                                                |");
                Console.WriteLine("|=========================================================================================================|");
                Console.Write("Ваш выбор: ");
                menu = Console.ReadLine();
                switch(menu)
                {
                    case "1":
                        {
                            Console.Clear();
                            for (int i = 0; i < n; i++)
                            {
                                if (emp[i].Hiredate[1] > 0 && emp[i].Hiredate[1] < 10)
                                {
                                    Console.WriteLine(i + 1 + ": " + "  Имя: " + emp[i].Name + "  Вакансия: " + emp[i].Vacancy + "  Зарплата:" + emp[i].Salary + "  Дата:" + emp[i].Hiredate[0] + "." + "0" + emp[i].Hiredate[1] + "." + emp[i].Hiredate[2]);
                                }
                                else
                                {
                                    Console.WriteLine(i + 1 + ": " + "  Имя: " + emp[i].Name + "  Вакансия: " + emp[i].Vacancy + "  Зарплата:" + emp[i].Salary + "  Дата:" + emp[i].Hiredate[0] + "." + emp[i].Hiredate[1] + "." + emp[i].Hiredate[2]);
                                }
                            }
                            Console.ReadKey();  
                        }
                        break;
                    case "2":
                        {
                            Vacancies vac;
                            Console.Clear();
                            Console.Write("Введите должность: ");
                            Console.WriteLine("1-manager , 2-boss, 3- clerk, 4-salesman");
                            int k= Convert.ToInt32(Console.ReadLine());
                            if (k > 0 && k < 5)
                            {
                                if (k == 1)
                                {
                                    Console.Clear();
                                    vac = Vacancies.Manager;
                                    k = 1;
                                    for (int i = 0; i < n; i++)
                                    {
                                        if (emp[i].Vacancy == vac)
                                        {
                                            Console.WriteLine((k +1)+ ": " + "  Имя: " + emp[i].Name + "  Вакансия: " + emp[i].Vacancy + "  Зарплата:" + emp[i].Salary + "  Дата:" + emp[i].Hiredate[0] + "." + emp[i].Hiredate[1] + "." + emp[i].Hiredate[2]);
                                            k++;
                                        }

                                    }
                                    Console.ReadKey();

                                }
                                if (k == 2)
                                {
                                    Console.Clear();
                                    vac = Vacancies.Boss;
                                    k = 1;
                                    for (int i = 0; i < n; i++)
                                    {
                                        if (emp[i].Vacancy == vac)
                                        {
                                            Console.WriteLine((k + 1) + ": " + "  Имя: " + emp[i].Name + "  Вакансия: " + emp[i].Vacancy + "  Зарплата:" + emp[i].Salary + "  Дата:" + emp[i].Hiredate[0] + "." + emp[i].Hiredate[1] + "." + emp[i].Hiredate[2]);
                                            k++;
                                        }

                                    }
                                    Console.ReadKey();

                                }
                                if (k == 3)
                                {
                                    Console.Clear();
                                    vac = Vacancies.Clerk;
                                    k = 1;
                                    for (int i = 0; i < n; i++)
                                    {
                                        if (emp[i].Vacancy == vac)
                                        {
                                            Console.WriteLine((k + 1) + ": " + "  Имя: " + emp[i].Name + "  Вакансия: " + emp[i].Vacancy + "  Зарплата:" + emp[i].Salary + "  Дата:" + emp[i].Hiredate[0] + "." + emp[i].Hiredate[1] + "." + emp[i].Hiredate[2]);
                                            k++;
                                        }
                                       

                                    }
                                    Console.ReadKey();

                                }
                                if (k == 4)
                                {
                                    Console.Clear();
                                    vac = Vacancies.Salesman;
                                    k = 1;
                                    for (int i = 0; i < n; i++)
                                    {
                                        if (emp[i].Vacancy == vac)
                                        {
                                            Console.WriteLine((k + 1) + ": " + "  Имя: " + emp[i].Name + "  Вакансия: " + emp[i].Vacancy + "  Зарплата:" + emp[i].Salary + "  Дата:" + emp[i].Hiredate[0] + "." + emp[i].Hiredate[1] + "." + emp[i].Hiredate[2]);
                                            k++;
                                        }
                                        

                                    }
                                    Console.ReadKey();

                                }
                            }
                            else
                            {
                                Console.WriteLine("Такого номера нет в списке");
                                Console.ReadKey();
                            }

                            }
                        break;
                    case "3":
                        {
                            double average=0;
                            int k = 0;
                            for (int i = 0; i < n; i++)
                            {
                                if (emp[i].Vacancy == Vacancies.Clerk)
                                {
                                    average = average + emp[i].Salary;
                                    k++;
                                }
                            }
                            average = average / k;
                            Employee[] emp1 = new Employee[n]; //Начало сортировки
                            for (int i = 0; i < n; i++)
                            {
                                emp1[i] = emp[i];
                            }
                            string[] cur = new string[n];
                            for (int i = 0; i < n; i++)
                            {
                                cur[i] = emp[i].Name;  
                            }
                            
                            Array.Sort(cur);
                            for (int i = 0; i < n; i++)
                            {
                                for (int j = 0; j < n; j++) {
                                    if (cur[i]== emp[j].Name)
                                    {
                                       emp1[i]=emp[j];
                                    }
                                    
                                }
                            } //Конец сортировки
                            Console.Clear();
                            Console.WriteLine("Средняя зп у Clerk'а= "+average);
                            k = 0;
                            for (int i = 0; i < n; i++)
                            {
                                if (emp1[i].Vacancy == Vacancies.Manager)
                                {
                                    if (emp1[i].Salary > average)
                                    {
                                        Console.WriteLine(k + ": " + "  Имя: " + emp1[i].Name + "  Вакансия: " + emp1[i].Vacancy + "  Зарплата:" + emp1[i].Salary + "  Дата:" + emp1[i].Hiredate[0] + "." + emp1[i].Hiredate[1] + "." + emp1[i].Hiredate[2]);
                                        k++;
                                    }

                                }
                            }
                            Console.ReadKey();

                            }
                        break;
                    case "4":
                        {
                            Employee[] emp1 = new Employee[n]; //Начало сортировки 
                            for (int i = 0; i < n; i++)
                            {
                                emp1[i] = emp[i];
                            }
                            string[] cur = new string[n];
                            for (int i = 0; i < n; i++)
                            {
                                cur[i] = emp[i].Name;
                            }

                            Array.Sort(cur);
                            for (int i = 0; i < n; i++)
                            {
                                for (int j = 0; j < n; j++)
                                {
                                    if (cur[i] == emp[j].Name)
                                    {
                                        emp1[i] = emp[j];
                                    }

                                }
                            } //Конец сортировки
                            int k = 0;
                            int   boss_number;
                            for (int i = 0; i < n; i++)
                            {
                                if (emp1[i].Vacancy == Vacancies.Boss)
                                {
                                     k = i;
                                }
                            }
                            boss_number = k;
                            k = 0;
                            int year = emp1[boss_number].Hiredate[2];
                            int month = emp1[boss_number].Hiredate[1];
                            int day = emp1[boss_number].Hiredate[0];
                            Console.Clear();
                            for (int i = 0; i < n; i++)
                            {
                                
                                    if (emp1[i].Hiredate[2]> emp1[boss_number].Hiredate[2])
                                    {
                                        Console.WriteLine(k + ": " + "  Имя: " + emp1[i].Name + "  Вакансия: " + emp1[i].Vacancy + "  Зарплата:" + emp1[i].Salary + "  Дата:" + emp1[i].Hiredate[0] + "." + emp1[i].Hiredate[1] + "." + emp1[i].Hiredate[2]);
                                        k++;
                                    }
                                if (emp1[i].Hiredate[2] == emp1[boss_number].Hiredate[2])
                                {
                                    if (emp1[i].Hiredate[1] > emp1[boss_number].Hiredate[1])
                                    {
                                        Console.WriteLine(k + ": " + "  Имя: " + emp1[i].Name + "  Вакансия: " + emp1[i].Vacancy + "  Зарплата:" + emp1[i].Salary + "  Дата:" + emp1[i].Hiredate[0] + "." + emp1[i].Hiredate[1] + "." + emp1[i].Hiredate[2]);
                                        k++;

                                    }
                                    if (emp1[i].Hiredate[1] == emp1[boss_number].Hiredate[1])
                                    {
                                        if (emp1[i].Hiredate[0] > emp1[boss_number].Hiredate[0])
                                        {
                                            Console.WriteLine(k + ": " + "  Имя: " + emp1[i].Name + "  Вакансия: " + emp1[i].Vacancy + "  Зарплата:" + emp1[i].Salary + "  Дата:" + emp1[i].Hiredate[0] + "." + emp1[i].Hiredate[1] + "." + emp1[i].Hiredate[2]);
                                            k++;
                                        }
                                        
                                    }
                                }



                            }
                            Console.ReadKey();




                        }
                        break;
                    case "0":
                        {
                            key = false;
                        }
                        break;
                }
            }
            while (key == true);
        }
    }
    
}