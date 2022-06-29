using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
 
namespace CopyFileUpper
{
    /// <summary>
    ///    Class to create an upper case copy of a file
    /// </summary>
    class CopyFileUpper
    {
        static void Main(string[] args)
        {
            string sFrom, sTo; // store file names
            StreamReader srFrom; //the variable is used to store a reference to the input file
            StreamWriter swTo; // the variable is intended to store a reference to the output stream
            
            // Read fileNames
            Console.WriteLine("Enter the name inputFile: ");
            sFrom = Console.ReadLine();
            Console.WriteLine("Enter the name outputFile: ");
            sTo = Console.ReadLine();
            try
            {
                srFrom = new StreamReader(sFrom);
                swTo = new StreamWriter(sTo);
                
                while (srFrom.Peek() != -1)
                {
                    string sBuffer = srFrom.ReadLine();
                    sBuffer = sBuffer.ToUpper(); // Up words
                    swTo.WriteLine(sBuffer); // write string in output file
                }
                srFrom.Close();
                swTo.Close();
 
            }
            catch (FileNotFoundException ex) // Catches a nonexistent file exception
            {
                Console.WriteLine(ex);
            }
            catch(Exception ex) // other exceptions
            {
                Console.WriteLine(ex);
            }
            Console.ReadKey();
        }
    }
}