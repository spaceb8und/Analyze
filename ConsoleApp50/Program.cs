Func<IEnumerable<string>?, List<int>> GetAllOfRange = range =>
{
    List<int> output = new List<int>();
    var type = range.LastOrDefault();
    for (int i = int.Parse(range.ToList()[0]); i <= int.Parse(range.ToList()[1]); i++)
    {
        if (type.Equals("odd") && i % 2 != 0
            || type.Equals("even") && i % 2 == 0)
        {
            output.Add(i);
        }
    }

    return output;
};
var input = Console.ReadLine()?.Split(' ').ToList();
input.Add(Console.ReadLine());
GetAllOfRange(input).ForEach(e => Console.Write(e + " "));