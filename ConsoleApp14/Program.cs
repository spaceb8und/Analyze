using System;
 
namespace Laba1
{
    class Greeter
    {
        static void Main(string[] args)
        {
            // Writes the specified data, followed by the current line terminator, to the standard output stream.
            Console.WriteLine("Please enter your name");
            // Reads the next line of characters from the standard input stream.
            string MyName = Console.ReadLine();
            Console.WriteLine("Hello, {0}", MyName);
            Console.ReadKey();
        }
    }
}

