class programm
{
    public struct Worker
    {
        public Worker(string _name, string _position, double _salary)
            : this()
        {
            name = _name;
            position = _position;
            salary = _salary;
        }

        public string name { get; set; }
        public string position { get; set; }
        public double salary { get; set; }
    }

    static void Main(string[] args)
    {
        Worker? w1 = null;

        Worker? w2 = new Worker("Петров Иван Николаевич", "Программист", 25000);

        if (w1 == null)
            Console.WriteLine("w1 is null");
        else
            Console.WriteLine("w1 is not null");

        if (w2 == null)
            Console.WriteLine("w2 is null");
        else
            Console.WriteLine("w2 is not null");
    }
}