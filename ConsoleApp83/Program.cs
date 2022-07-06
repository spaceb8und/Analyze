using System;

namespace LR_2_1
{
    class ArrayVector
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
            for (int i = 0; i < n ; i++)
            {
                mas[i] = Convert.ToDouble(Console.ReadLine());
            }
        }

        public void SetElement(int k, double m)
        {
            k = k - 1;
            mas[k] = m;

        }
        public void GetElement(int k)
        {
            int n = k;
            k = k - 1;
            Console.WriteLine("Элемент под номером " + n + " = " + mas[k]);
        }
        public void GetNorm()
        {
            double s = 0;
            for (int i = 0; i < n ; i++)
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
                if (mas[i]==0)
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
            for (int i = 0; i < n ; i++)
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
            for (int i = 0; i < n ; i++)
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
    class Vectors
    {
        public static ArrayVector Sum(ArrayVector v1,ArrayVector v2)
        {
            if (v1.n == v2.n)
            {
                ArrayVector v = new ArrayVector(v1.n);
                for (int i = 0; i < v1.n; i++)
                {
                    v.mas[i] = v1.mas[i] + v2.mas[i];
                }
                return v;
            }
            else
            {
                Console.WriteLine("Длины векторов не совпадают, будет возвращен нулевой вектор");
                ArrayVector v = new ArrayVector();
                for (int i = 0; i < v.n; i++)
                {
                    v.mas[i] = 0;
                }
                return v;
            }
           
        }
        public static double Scalar(ArrayVector v1, ArrayVector v2)
        {
            double s = 0;
            if (v1.n == v2.n)
            {
                for (int i = 0; i < v1.n ; i++)
                {
                    s = s + v1.mas[i] * v2.mas[i];
                }
                
                return s;
            }
            else
            {
                Console.WriteLine("Длины векторов не совпадают, , будет возвращен 0");
                return 0;
            }
        }
        public static ArrayVector NumberMul(ArrayVector v1,double m)
        {
            
            for (int i = 0; i < v1.n ; i++)
            {
                v1.mas[i] = v1.mas[i] * m;
            }
            return v1;
        }
        public static double GetNorm(ArrayVector v)
        {
            double s = 0;
            for (int i = 0; i < v.n; i++)
            {
                s = s + v.mas[i] * v.mas[i];
            }
            s= Math.Sqrt(s);
            return s;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Трофимов Михаил, группа 6115-020302D, Лабораторная работа №1");
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
                Console.WriteLine("Трофимов Михаил, группа 6115-020302D, Лабораторная работа №1");
                Console.Write("вектор 1 = " );
                v1.vivod();
                Console.WriteLine();
                Console.Write("вектор 2 = ");
                v2.vivod();
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
            Console.WriteLine("Для получения модуля первого вектора(ПО КЛАССУ Vectors) нажмите '23' ");
            Console.WriteLine("Для получения модуля второго вектора(ПО КЛАССУ Vectors) нажмите '24'  ");

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
                            v1.vivod();
                            int k;
                            double m;
                            Console.WriteLine("Введите номер заменяемой координаты");
                            k = Convert.ToInt32(Console.ReadLine());
                            if ((k < v1.n)&& (k > 0))
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
                            v2.vivod();
                            int k;
                            double m;
                            
                                Console.WriteLine("Введите номер заменяемой координаты");
                                k = Convert.ToInt32(Console.ReadLine());
                                if ((k < v2.n)&& (k > 0))
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
                            v1.vivod();
                            Console.WriteLine("Введите номер координаты ,которую хотите прочесть");
                            k = Convert.ToInt32(Console.ReadLine());
                            if ((k < v1.n)&&(k>0))
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
                            v2.vivod();
                            Console.WriteLine("Введите номер координаты ,которую хотите прочесть");
                            k = Convert.ToInt32(Console.ReadLine());
                            if ((k < v1.n)&& (k > 0))
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
                            ArrayVector v3 = Vectors.Sum(v1, v2);
                            Console.WriteLine("сумма векторов=" + v3);
                            Console.ReadKey();
                        }
                        break;
                    case "20":
                        {
                            Console.Clear();
                            double v3 = Vectors.Scalar(v1, v2);

                            Console.WriteLine("скалярное произведение=" + v3);
                            Console.ReadKey();
                        }
                        break;
                    case "21":
                        {
                            Console.Clear();
                            Console.WriteLine("Введите число на которое хотите умножить вектор");
                            double k = Convert.ToDouble(Console.ReadLine());
                            ArrayVector v3 = Vectors.NumberMul(v1, k);
                            Console.WriteLine("произведение вектора на число=" + v3);
                            Console.ReadKey();
                        }
                        break;
                    case "22":
                        {
                            Console.Clear();
                            Console.WriteLine("Введите число на которое хотите умножить вектор");
                            double k = Convert.ToDouble(Console.ReadLine());
                            ArrayVector v3 = Vectors.NumberMul(v2, k);
                            Console.WriteLine("произведение вектора на число=" + v3);
                            Console.ReadKey();
                        }
                        break;
                        
                    case "23":
                        {
                            Console.Clear();
                            double v3 = Vectors.GetNorm(v1);
                            if (v3 != 0)
                            {
                                Console.WriteLine("модуль вектора=" + v3);
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Введен нулевой вектор(точка)");
                                Console.ReadKey();
                            }

                        }
                        break;
                        
                    case "24":
                        {
                            Console.Clear();
                            double v3 = Vectors.GetNorm(v2);
                            if (v3 != 0)
                            {
                                Console.WriteLine("модуль вектора=" + v3);
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Введен нулевой вектор(точка)");
                                Console.ReadKey();
                            }
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
    }
}
