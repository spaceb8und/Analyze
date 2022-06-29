using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApp31
{
    class Program
    {
        private static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            List<int> arr = new List<int>();
            for (int i = 0; i < 50; i++)
            {
                foo(arr);
                add(arr);
            }
            StreamWriter sw = new StreamWriter("text.txt");
            sw.Write(sb.ToString());
            sw.Close();
        }

        static void foo(List<int> arr)
        {
            arr.Clear();
            for (int i = 0; i < 6; i++)
            {
                arr.Add(new Random().Next(0, 2));
            }
        }

        static void add(List<int> arr)
        {
            string str = "";
            for (int i = 0; i < 6; i++)
            {
                str = str + arr[i] + " ";
            }

            sb.AppendLine(str);
        }
    }
}