Func<int[]?, int> GetMin = arr => (arr ?? Array.Empty<int>()).Min();
var collection = Console.ReadLine()?.Split(" ").Select(int.Parse).ToArray();
Console.Write(GetMin(collection));