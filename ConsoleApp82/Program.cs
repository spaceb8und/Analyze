using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace StreamReaderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:\\textfile.txt");

            string s;

            while (sr.EndOfStream != true)
            {
                s = sr.ReadLine();

                Console.WriteLine(s);
            }

            sr.Close();
        }
    }
}