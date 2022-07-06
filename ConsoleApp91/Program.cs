using System;

namespace Set_of_real_numbers
{
    class RealSet
    {
        float[] x;

        public RealSet(int n)
        {
            x = new float[n];
        }

        public RealSet()
        {

        }

        public void Input(string s)
        {
            Console.WriteLine("Введите " + x.GetLength(0) + " элемента(ов) множества " + s + ":");
            for (int i = 0; i < x.GetLength(0); i++)
            {
                x[i] = (float)Convert.ToDouble(Console.ReadLine());
            }
        }

        public static RealSet operator /(RealSet A, RealSet B)
        {
            int i, j;
            int k = 0; //количество элементов множества С
            bool flag = false; //есть ли в множестве В элемент А[i]
            //определяем количество элементов множества С
            for (i = 0; i < A.x.GetLength(0); i++)
            {
                for (j = 0; j < B.x.GetLength(0); j++)
                {
                    if (A.x[i] == B.x[j])
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                    k++;
                else
                    flag = false;
            }

            //заполняем множество result результатом вычитания множеств A и B
            RealSet result = new RealSet(k);
            k = 0;
            for (i = 0; i < A.x.GetLength(0); i++)
            {
                for (j = 0; j < B.x.GetLength(0); j++)
                {
                    if (A.x[i] == B.x[j])
                    {
                        flag = true;
                        break;
                    }
                }

                if (!flag)
                {
                    result.x[k] = A.x[i];
                    k++;
                }
                else
                    flag = false;
            }

            return result;
        }

        public void Output(string s)
        {
            Console.Write(s + " = {");
            for (int i = 0; i < x.GetLength(0); i++)
                Console.Write(x[i] + " ");
            Console.Write("}\n");
        }


        class Program
        {
            static void Main(string[] args)
            {
                int n;
                Console.Write("Введите количество элементов множества А: ");
                n = Convert.ToInt32(Console.ReadLine());
                RealSet A = new RealSet(n);
                A.Input("A");
                Console.Write("Введите количество элементов множества B: ");
                n = Convert.ToInt32(Console.ReadLine());
                RealSet B = new RealSet(n);
                B.Input("B");

                RealSet C = A / B;
                //тоже работает
                //RealSet C = new RealSet();
                //C = A / B;

                Console.WriteLine();
                A.Output("A");
                B.Output("B");
                C.Output("C");

                Console.ReadLine();
            }
        }
    }
}
