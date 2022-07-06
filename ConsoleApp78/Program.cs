class Programm
{
    static int[] ViborSort(int[] mas)
{
            
    for (int i = 0; i < mas.Length - 1; i++)
    {
        //поиск минимального числа
        int min=i;
        for (int j = i + 1; j < mas.Length; j++)
        {
            if (mas[j] < mas[min])
            {
                min = j;
            }
        }
        //обмен элементов
        int temp = mas[min];
        mas[min] = mas[i];
        mas[i] = temp;
    }
    return mas;
}
    static void Main(string[] args)
    {
        Console.WriteLine("Ведите количество чисел для сортировки.");
        int N = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите числа для сортировки:");
        int[] mas = new int[N];
        for (int i = 0; i < mas.Length; i++)
        {
            mas[i] = Convert.ToInt32(Console.ReadLine());
        }
        ViborSort(mas);
        Console.WriteLine("Отсортированный массив:");
        for (int i = 0; i < mas.Length; i++)
        {
            Console.WriteLine( mas[i]);
        }
        Console.ReadLine();
    }
    
}