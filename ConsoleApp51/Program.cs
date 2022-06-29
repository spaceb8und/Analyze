Func<int, int>? GetFunc(string? command)
{
    switch (command)
    {
        case "add": return e => e + 1;
        case "subtract": return e => e - 1;
        case "multiply": return e => e * 2;
    }

    return null;
}

void ExecuteCommand(List<int>? list, Func<int, int>? func)
{
    if (func != null)
    {
        for (int i = 0; i < list?.Count; i++)
        {
            list[i] = func(list[i]);
        }
    }
    else
    {
        list?.ForEach(e => Console.Write(e + " "));
        Console.WriteLine();
    }
}

var collection = Console.ReadLine()?.Split(" ").Select(int.Parse).ToList();
 var command = Console.ReadLine();
 while (!string.Equals(command, "end"))
{
    ExecuteCommand(collection, GetFunc(command)); 
    command = Console.ReadLine();
}

