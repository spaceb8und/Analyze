// Напишите программу, которая считывает набор слов в строку через пробел из консоли,
// а затем печатает их в консоль так, чтобы каждая строка была напечатана в новой строке.
// Используйте Action<Т>.

using System.Collections;


Action<string> WriteLn = s => Console.WriteLine(s);
Console.ReadLine()?.Split(" ").ToList().ForEach(WriteLn);