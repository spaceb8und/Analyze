void PrintIf(string name, Predicate<string> condition)
{
    if (condition(name))
        Console.Write(name + " ");
}

var n = int.Parse(Console.ReadLine() ?? String.Empty);
Console.ReadLine()?.Split(' ')
    .ToList().ForEach(name => PrintIf(name, name => name.Length <= n));