Action<string> WriteLnWithEnding = s => Console.WriteLine($"{s} (нет в наличии)");
Console.ReadLine()?.Split(" ").ToList().ForEach(WriteLnWithEnding);