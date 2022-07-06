Random rand = new Random();
Console.WriteLine("Сколько чисел вы хотите вывести?");
string s = Console.ReadLine();
int a = Convert.ToInt32(s);
for (int i=0;i<a;i++)
{
    Console.WriteLine(rand.Next(100));
}
rand.Next(50, 1000);
Console.ReadLine();