static void Main(string[] args)
{
    Console.WriteLine("Введите десятичное число:");
    int i = Convert.ToInt32(Console.ReadLine());
    string s= Convert.ToString(i, 2);
    Console.WriteLine("В двоичной системе счисления это: "+s);
    Console.ReadLine();
}