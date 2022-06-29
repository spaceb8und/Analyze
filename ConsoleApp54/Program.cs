using System.Collections;


    var array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    int Comparer(int a, int b)
    {
        if (a % 2 == 0)
        {
            if (b % 2 == 0)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
        else
        {
            if (b % 2 == 0)
            {
                return 0;
            }
            else
            {
                return a.CompareTo(b);
            }
        }
    }

    Array.Sort(array, Comparer);

    foreach (var a in array)
    {
        Console.WriteLine(a);
    }
