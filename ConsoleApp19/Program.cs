using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO; // FileStream, FileReader
using System.Threading.Tasks;
 
namespace FileDetails
{
    class Program
    {
 
        public static void Summerize(char[] contents)
        {
            string set_vowels = "AEIOUaeiou";  // map vowels
            string set_consonants = "BCDFGHJKLMNPQRSTVWXYZbcdfghjklmnpqrstvwxyz"; // map consonants
            uint vowels = 0;
            uint consonants = 0; 
            uint switchLine = 0; //  number of '\n'
            char Switch = '\n';
 
            foreach (char ch in contents) {
                if (set_consonants.IndexOf(ch) != -1)
                {
                    consonants++;
                }
                else if (set_vowels.IndexOf(ch) != -1)
                {
                    vowels++;
                }
                else if (ch == '\n')
                {
                    switchLine++;
                }
            }
            Console.WriteLine($"The number of consonant letters in the file: {consonants}");
            Console.WriteLine($"The number of vowels letters in the file: {vowels}");
            Console.WriteLine($"The number of transitions to the next line in the file: {switchLine}");
 
        }
        static void Main(string[] args)
        {
            foreach(string arg in args)
            {
                Console.WriteLine(arg);
            }
            string fileName = args[0]; // args[0] - file name
            Console.WriteLine(fileName); // out file name
            FileStream stream = new FileStream(fileName, FileMode.Open); 
            StreamReader reader = new StreamReader(stream);  // stream
            long lenFile = stream.Length;  // len file
            Console.WriteLine(lenFile);
            char[] contents = new char[lenFile];
            // reading characters from a file
            for (uint i = 0; i < lenFile; i++) 
            {
                contents[i] = (char)reader.Read(); 
            }
            reader.Close(); // close stream
            Summerize(contents);
            int realLen = 0;
            foreach(char ch in contents)
            {
                realLen++;
                Console.Write(ch);
            }
            if (realLen != lenFile)
            {
                throw new Exception();
            }
            //TODO: Add code here
        }
 
    }
}

