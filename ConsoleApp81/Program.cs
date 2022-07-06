using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace wordscount
{
    class Program
    {
        static void Main(string[] args)
        {       
            string s = "" ;
            string[] textMass;
            StreamReader sr = new StreamReader("C:\\textfile.txt");

            while (sr.EndOfStream != true)
            {
                s += sr.ReadLine();                
            }
            textMass = s.Split(' ');
            Console.WriteLine("Количество слов:");
            Console.WriteLine(textMass.Length);

            sr.Close();
            Console.ReadLine();
        }
    }
}