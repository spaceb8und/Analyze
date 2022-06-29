Func<int, int, bool> IsNotshared = (n, divider) => n % divider != 0;

 var list = Console.ReadLine()?.Split(' ').Select(int.Parse);
 var n = int.Parse(Console.ReadLine() ?? string.Empty);
list.Where(e => IsNotshared(e, n))
    .Reverse().ToList().ForEach(e => Console.Write(e + " "));