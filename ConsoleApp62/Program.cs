namespace infinite_loop
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            for (; ; )
            {
                i++;
                Console.WriteLine(i);
            }
        }
    }
}