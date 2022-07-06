using System;

namespace LR_2_4_________
{
    public class Vectors
    {
        public static IVector Sum(IVector v1, IVector v2)
        {
            if (v1.Length == v2.Length)
            {
                ArrayVector v = new ArrayVector(v1.Length);
                for (int i = 0; i < v1.Length; i++)
                {
                    v.mas[i] = v1[i] + v2[i];
                }
                return v;
            }
            else
            {
                Console.WriteLine("Длины векторов не совпадают");
                ArrayVector v = new ArrayVector();
                for (int i = 0; i < v.Length; i++)
                {
                    v.mas[i] = 0;
                }
                return v;
            }

        }
        public static double Scalar(IVector v1, IVector v2)
        {
            double s = 0;
            if (v1.Length == v2.Length)
            {
                for (int i = 0; i < v1.Length; i++)
                {
                    s = s + v1[i] * v2[i];
                }

                return s;
            }
            else
            {
                Console.WriteLine("Длины векторов не совпадают, , будет возвращен 0");
                return 0;
            }
        }
        public static ArrayVector NumberMul(ArrayVector v1, double m)
        {

            for (int i = 0; i < v1.n; i++)
            {
                v1.mas[i] = v1.mas[i] * m;
            }
            return v1;
        }
        public static double GetNorm(IVector v)
        {
            double s = 0;
            for (int i = 0; i < v.Length; i++)
            {
                s = s + v[i] * v[i];
            }
            s = Math.Sqrt(s);
            return s;
        }
    }
     public class LinkedListVector:IVector
    {
        private class Node
        {
            public Node next;
            public double data;
            public Node()
            {
                next = null;
                data = 0;
            }
            public Node(double t)
            {
                next = null;
                data = t;
            }
            public Node Next
            {
                get { return next; }
                set { next = value; }
            }
            public double Data
            {
                get { return data; }
                set { data = value; }
            }
        }

        private Node head;

        public LinkedListVector()
        {
            for (int i = 0; i < 5; i++) Add(0);
        }
        public LinkedListVector(int n)
        {

            for (int i = 0; i < n; i++) Add(0);
        }

        public void Add(double data)
        {

            Node n = new Node(data);
            if (head == null) head = n;
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = n;
            }

        }
        public double this[int index]
        {
            get
            {
                int k = 0;
                Node cur = head;
                while (cur != null)
                {
                    k += 1;
                    cur = cur.next;
                }
                Node current = head;
                if (k >= index & index >= 0)
                {
                    for (int i = 0; i < index; i++) if (current.Next == null) throw new IndexOutOfRangeException("Индекс списка  вне границы массива");
                        else current = current.Next;
                    return current.Data;
                }
                else throw new IndexOutOfRangeException("Индекс списка  вне границы массива");
            }
            set
            {
                Node current = head;
                for (int i = 0; i <= index; i++) if (current.Next == null) throw new IndexOutOfRangeException("Индекс списка вне границы массива");
                    else current = current.Next;
                current.Data = value;
            }
        }
        void IVector.GetNorm()
        {
            double sum = 0;
            Node cur = head;
            while (cur != null)
            {
                sum += cur.data * cur.data;
                cur = cur.next;
            }
            Console.WriteLine($"Модуль вектора равен {Math.Sqrt(sum)}");
        }
        public int Length
        {
            get
            {
                int k = 0;
                Node cur = head;
                while (cur != null)
                {
                    k += 1;
                    cur = cur.next;
                }

                return k;
            }

        }
        public override string ToString()
        {
            Node cur = head;
            string str = new string("");
            Console.Write(Length+": ");
            while (cur != null)
            {
                str += cur.data;
                str += " ";
                cur = cur.next;
            }
            return str;
        }
    }
     
     public interface IVector
     {
         double this[int index]
         {
             get;
             set;
         }
         int Length
         {
             get;
         }
         void GetNorm();
        
     }
      public class ArrayVector:IVector
    {
        public int n;
        public double[] mas;
        public ArrayVector(int n)
        {
            this.n = n;
            mas = new double[n];
        }
        public ArrayVector()
        {
            n = 5;
            mas = new double[5];

        }
        public void vvod()
        {
            Console.WriteLine("Введите значения вектора с 1 по " + n);
            for (int i = 0; i < n; i++)
            {
                mas[i] = Convert.ToDouble(Console.ReadLine());
            }
        }

        public void SetElement(int k, double m)
        {
            if (k <= mas.Length && k > 0)
            {

                k = k - 1;
                mas[k] = m;

            }

            else
            {
                Console.WriteLine("Введено отрицательное число или строка");
            }

        }
        public void GetElement(int k)
        {
            if (k<=mas.Length && k>0)
            {
                int n = k;
                k = k - 1;
                Console.WriteLine("Элемент под номером " + n + " = " + mas[k]);
            }
            else
            {
                Console.WriteLine("Введено отрицательное число или строка");
            }
        }
        public double this[int index]
        {
            get
            {
                if ((0 < index) && (index <= mas.Length))
                {
                    return mas[index - 1];
                }
                else
                {
                    Console.WriteLine("Индекс выходит за пределы массива");
                    return 0;
                }
            }
            set
            {
                if ((0 < index) && (index <= mas.Length))
                {
                    mas[index - 1] = value;
                }
                else
                {
                    Console.WriteLine("Индекс выходит за пределы массива");
                }
            }
        }
        public void GetNorm()
        {
            
                double s = 0;
                for (int i = 0; i < n; i++)
                {
                    s = s + mas[i] * mas[i];
                }
                s = Math.Sqrt(s);
                if (s != 0)
                {
                    Console.WriteLine("Длина вектора= " + s);
                }
                else
                {
                    Console.WriteLine("Введен нулевой вектор(точка)");
                    Console.ReadKey();
                }
            
        }
        public int Length
        {
            get
            {
                return mas.Length;
            }
        }
        public override string ToString()
        {
            string str = new string("");
            Console.Write(Length + ": ");
            for (int i = 0; i < Length; i++)
            {
                str += mas[i];
                str += " ";
            }
            return str;
        }
        public void vivod()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(mas[i] + "    ");
            }

        }
        public void SumPositivesFromChetIndex()
        {
            bool key2 = true;
            bool key1 = false;
            for (int i = 0; i < n; i++)
            {
                if (mas[i] == 0)
                {
                    key2 = false;
                }
                else
                {
                    key1 = true;
                }
            }
            if (key1 == true)
            {
                double s = 0;
                for (int i = 0; i < n; i++)
                {
                    if (((i + 1) % 2 == 0) && (mas[i] > 0))
                    {
                        s = s + mas[i];
                    }
                }
                vivod();
                Console.Write("сумма всех положительных элементов массива с четными номерами = " + s);
            }
            else
            {
                Console.Write("Все элементы нулевые");
            }


        }
        public void SumLessFromNechetIndex()
        {
            bool key2 = true;
            bool key1 = false;
            for (int i = 0; i < n; i++)
            {
                if (mas[i] == 0)
                {
                    key2 = false;
                }
                else
                {
                    key1 = true;
                }
            }
            if (key1 == true)
            {
                int k;
                double s = 0;
                double sred = 0;
                for (int i = 0; i < n; i++)
                {
                    sred = sred + Math.Abs(mas[i]);
                }
                sred = sred / n;
                for (int i = 0; i < n; i++)
                {
                    k = i + 1;
                    if (((k % 2) != 0) && (mas[i] < sred))
                    {
                        s = s + mas[i];
                    }
                }
                vivod();
                Console.WriteLine("Среднее значение=" + sred);


                Console.Write("сумма тех элементов массива, которые имеют нечетные номера и  одновременно меньше среднего значения всех модулей элементов массива " + s);
            }
            else
            {
                Console.Write("Все элементы массива нулевые");
            }
        }
        public void MulChet()
        {
            double s = 1;
            for (int i = 0; i < n; i++)
            {
                if ((mas[i] % 2 == 0) && (mas[i] > 0))
                {
                    s = s * mas[i];
                }
            }
            if (s != 1)
            {
                Console.Write("произведение всех четных положительных элементов = " + s);
            }
            else
            {
                Console.WriteLine("Ни один из элементов массива не удволетворял условиям");
            }
        }
        public void MulNechet()
        {
            double s = 1;
            for (int i = 0; i < n; i++)
            {
                if ((mas[i] % 2 != 0) && (mas[i] % 3 != 0))
                {
                    s = s * mas[i];
                }
            }
            if (s != 1)
            {
                Console.Write("произведение всех нечетных элементов, не делящихся на три = " + s);
            }
            else
            {
                Console.WriteLine("Ни один из элементов массива не удволетворял условиям");
            }
        }
        public void SortUp()
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        double c = mas[i];
                        mas[i] = mas[j];
                        mas[j] = c;
                    }
                }
            }
            Console.WriteLine("Вывод по возрастанию:");
            vivod();

        }
        public void SortDown()
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (mas[i] < mas[j])
                    {
                        double c = mas[i];
                        mas[i] = mas[j];
                        mas[j] = c;
                    }
                }
            }
            Console.WriteLine("Вывод по убыванию:");
            vivod();

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string menuMain;
            bool keyMain = true;
            do
            {
                Console.WriteLine("Трофимов Михаил, группа 6115-020302D, Лабораторная работа №4");
                Console.WriteLine("Введите 1 для работы с 2 векторами");
                Console.WriteLine("Введите 2 для работы со списком   ");

                menuMain = Console.ReadLine();
                switch (menuMain)
                {
                    case "1":
                        {
                            Console.Clear();
                            Console.WriteLine("Трофимов Михаил, группа 6115-020302D, Лабораторная работа №4");
                            Console.WriteLine("Введите размерность первого вектора");
                            int n1 = Convert.ToInt32(Console.ReadLine());
                            ArrayVector v1 = new ArrayVector(n1);
                            v1.vvod();


                            Console.WriteLine("Введите размерность второго вектора");
                            int n2 = Convert.ToInt32(Console.ReadLine());
                            ArrayVector v2 = new ArrayVector(n2);
                            v2.vvod();

                            bool key = true;
                            string menu;

                            Console.Clear();

                            while (key == true)
                            {
                                Console.WriteLine("Трофимов Михаил, группа 6115-020302D, Лабораторная работа №4");
                                Console.Write("вектор 1 = ");
                                Console.WriteLine(v1);
                                Console.WriteLine();
                                Console.Write("вектор 2 = ");
                                Console.WriteLine(v2);
                                Console.WriteLine();
                                Console.WriteLine("Для установки значения координаты первого  вектора по индеку  нажмите '1' ");
                                Console.WriteLine("Для установки значения координаты второго вектора по индеку  нажмите '2' ");
                                Console.WriteLine("Для получения модуля первого вектора нажмите '3' ");
                                Console.WriteLine("Для получения модуля второго вектора нажмите '4' ");
                                Console.WriteLine("Для чтения элемента первого вектора по индексу нажмите '5' ");
                                Console.WriteLine("Для чтения элемента второго вектора по индексу нажмите '6' ");
                                Console.WriteLine("Для подсчета суммы всех положительных элементов первого вектора с четными номерами нажмите '7'");
                                Console.WriteLine("Для подсчета суммы всех положительных элементов второго вектора с четными номерами нажмите '8'");
                                Console.WriteLine("Для подсчета суммы тех элементов первого вектора, которые имеют нечетные номера и  одновременно меньше среднего значения всех модулей элементов вектора нажмите '9'  ");
                                Console.WriteLine("Для подсчета суммы тех элементов второго вектора, которые имеют нечетные номера и  одновременно меньше среднего значения всех модулей элементов вектора '10' ");
                                Console.WriteLine("Для подсчета произведения всех четных положительных элементов первого ветктора нажмите '11'");
                                Console.WriteLine("Для подсчета произведения всех четных положительных элементов второго ветктора нажмите '12'");
                                Console.WriteLine("Для подсчета произведения всех нечетных элементов первого вектора, не делящихся на три нажмите '13' ");
                                Console.WriteLine("Для подсчета произведения всех нечетных элементов второго вектора, не делящихся на три нажмите '14'");
                                Console.WriteLine("Для сортировки первого вектора по возрастанию нажмите '15' ");
                                Console.WriteLine("Для сортировки второго вектора по возрастанию нажмите '16'");
                                Console.WriteLine("Для сортировки первого вектора по убыванию нажмите '17'");
                                Console.WriteLine("Для сортировки второго вектора по убыванию нажмите '18'");
                                Console.WriteLine("Для сложения двух векторов нажмите '19' ");
                                Console.WriteLine("Для скалярного произведения двух векторов нажмите '20' ");
                                Console.WriteLine("Для умножения первого вектора на число нажмите '21'  ");
                                Console.WriteLine("Для умножения второго вектора на число нажмите '22'  ");

                                Console.WriteLine("Для выхода нажмите  '0'");
                                menu = Console.ReadLine();


                                switch (menu)
                                {
                                    case "0":
                                        {
                                            key = false;
                                        }
                                        break;
                                    case "1":
                                        {
                                            Console.Clear();
                                            Console.WriteLine(v1);
                                            int k;
                                            double m;
                                            Console.WriteLine("Введите номер заменяемой координаты");
                                            k = Convert.ToInt32(Console.ReadLine());
                                            if ((k <= v1.Length) && (k > 0))
                                            {
                                                Console.WriteLine("Введите значение координаты");
                                                m = Convert.ToDouble(Console.ReadLine());

                                                v1.SetElement(k, m);
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Такого элемента не существует");
                                                Console.ReadKey();
                                            }
                                        }
                                        break;
                                    case "2":
                                        {
                                            Console.Clear();
                                            Console.WriteLine(v2);
                                            int k;
                                            double m;

                                            Console.WriteLine("Введите номер заменяемой координаты");
                                            k = Convert.ToInt32(Console.ReadLine());
                                            if ((k <= v2.Length) && (k > 0))
                                            {
                                                Console.WriteLine("Введите значение координаты");
                                                m = Convert.ToDouble(Console.ReadLine());

                                                v2.SetElement(k, m);
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Такого элемента не существует");
                                                Console.ReadKey();
                                            }


                                        }
                                        break;
                                    case "3":
                                        {
                                            Console.Clear();
                                            v1.GetNorm();
                                            Console.ReadKey();

                                        }
                                        break;
                                    case "4":
                                        {
                                            Console.Clear();
                                            v2.GetNorm();
                                            Console.ReadKey();

                                        }
                                        break;
                                    case "5":
                                        {
                                            Console.Clear();
                                            int k;
                                            Console.WriteLine(v1);
                                            Console.WriteLine("Введите номер координаты ,которую хотите прочесть");
                                            k = Convert.ToInt32(Console.ReadLine());
                                            if ((k <= v1.Length) && (k > 0))
                                            {
                                                v1.GetElement(k);
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Такого элемента не существует");
                                                Console.ReadKey();
                                            }


                                        }
                                        break;
                                    case "6":
                                        {
                                            Console.Clear();
                                            int k;
                                            Console.WriteLine(v2);
                                            Console.WriteLine("Введите номер координаты ,которую хотите прочесть");
                                            k = Convert.ToInt32(Console.ReadLine());
                                            if ((k <= v1.Length) && (k > 0))
                                            {
                                                v2.GetElement(k);
                                                Console.ReadKey();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Такого элемента не существует");
                                                Console.ReadKey();
                                            }
                                        }
                                        break;
                                    case "7":
                                        {
                                            Console.Clear();
                                            v1.SumPositivesFromChetIndex();
                                            Console.ReadKey();

                                        }
                                        break;
                                    case "8":
                                        {
                                            Console.Clear();
                                            v2.SumPositivesFromChetIndex();
                                            Console.ReadKey();

                                        }
                                        break;
                                    case "9":
                                        {
                                            Console.Clear();
                                            v1.SumLessFromNechetIndex();
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "10":
                                        {
                                            Console.Clear();
                                            v2.SumLessFromNechetIndex();
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "11":
                                        {
                                            Console.Clear();
                                            v1.MulChet();
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "12":
                                        {
                                            Console.Clear();
                                            v2.MulChet();
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "13":
                                        {
                                            Console.Clear();
                                            v1.MulNechet();
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "14":
                                        {
                                            Console.Clear();
                                            v2.MulNechet();
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "15":
                                        {
                                            Console.Clear();
                                            v1.SortUp();
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "16":
                                        {
                                            Console.Clear();
                                            v2.SortUp();
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "17":
                                        {
                                            Console.Clear();
                                            v1.SortDown();
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "18":
                                        {
                                            Console.Clear();
                                            v2.SortDown();
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "19":
                                        {
                                            Console.Clear();
                                            IVector v3 = Vectors.Sum(v1, v2);
                                            Console.Write("сумма векторов="+ v3);
                                            
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "20":
                                        {
                                            Console.Clear();
                                            double scal = Vectors.Scalar(v1, v2);

                                            Console.WriteLine("скалярное произведение=" + scal);
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "21":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Введите число на которое хотите умножить вектор");
                                            double k = Convert.ToDouble(Console.ReadLine());
                                            IVector v3 = Vectors.NumberMul(v1, k);
                                            Console.Write("произведение вектора на число="+ v3);
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "22":
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Введите число на которое хотите умножить вектор");
                                            double k = Convert.ToDouble(Console.ReadLine());                                            
                                            Console.Write("произведение вектора на число="+ Vectors.NumberMul(v2, k));                                           
                                            Console.ReadKey();
                                        }
                                        break;

                                    
                                    default:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Такого номера нет в списке ,повторите попытку");
                                            Console.ReadKey();

                                        }
                                        break;



                                }
                            }

                        }
                        break;
                    case "2":
                        {
                            Console.Clear();
                            Console.WriteLine("Трофимов Михаил, группа 6115-020302D, Лабораторная работа №4");
                            bool key3 = true;
                            int n;
                            double element;
                            Console.Clear();
                            Console.Write("Введите длинну списка: ");

                            n = Convert.ToInt32(Console.ReadLine());
                            LinkedListVector list = new LinkedListVector(n);
                            Console.WriteLine("Введите элементы списка");
                            for (int i = 0; i < n; i++)
                            {

                                element = Convert.ToDouble(Console.ReadLine());
                                list[i - 1] = element;
                            }
                            


                            string menu3;
                            do
                            {
                                Console.Clear();
                                Console.WriteLine("Трофимов Михаил, группа 6115-020302D, Лабораторная работа №4");
                                Console.Write("Список: ");
                                
                                Console.Write(list);
                                Console.WriteLine();
                                Console.WriteLine("Модуль списка '1'      ");
                                Console.WriteLine("Длина списка '2'       ");
                                Console.WriteLine("Выйти из этого меню '0'");


                                Console.WriteLine();
                                Console.Write("Введите номер:   ");
                                menu3 = Console.ReadLine();

                                switch (menu3)
                                {
                                    case "1":
                                        {
                                            ((IVector)list).GetNorm();
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "2":
                                        {
                                            Console.WriteLine("Длина списка: {0}", list.Length);
                                            Console.ReadKey();
                                        }
                                        break;
                                    case "3":
                                        {
                                            try
                                            {
                                                int k;
                                                Console.WriteLine("Введите индекс заменяемого элемента");

                                                k = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Введите значение");
                                                double d = Convert.ToDouble(Console.ReadLine());
                                                list[k] = d;


                                                Console.ReadKey();
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Ошибка: Введена строка или произошел выход за пределы массива");
                                            }
                                        }
                                        break;

                                    case "0":
                                        {
                                            key3 = false;
                                        }
                                        break;

                                    default:
                                        {
                                            Console.WriteLine("Неизвестная команда, введите другую");
                                            Console.ReadKey();
                                        }
                                        break;


                                }


                            }
                            while (key3 == true);

                        }
                        break;

                }
            }
            while (keyMain == true);
        }
    }
}