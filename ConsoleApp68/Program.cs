using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            string proverb = "Без труда не вытащишь рыбку из пруда";

            string substring1 = "да";

            string substring2 = "нет";

            Console.WriteLine(proverb.IndexOf(substring1));

            Console.WriteLine(proverb.IndexOf(substring2));

            Console.WriteLine(proverb.IndexOf(substring1, 10));

            Console.WriteLine(proverb.LastIndexOf(substring1));
        }
    }
}