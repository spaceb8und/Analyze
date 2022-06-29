using System;
using System.Collections.Generic;
using System.Linq;

namespace HigherSorting
{
    class Program
    {
        static void Main(string[] args) {
            IEnumerable<int> input = Console.ReadLine()?.Split(" ").Select(int.Parse);
            var output = Sort(input, Int32.Parse(Console.ReadLine() 
                                                 ?? throw new InvalidOperationException()), 2000);
            foreach (var v in output) {
                Console.Write(v + " ");
            }
        }

        /// <summary>
        /// Возвращает отсортированный по возрастанию поток чисел
        /// </summary>
        /// <param name="inputStream">Поток чисел от 0 до maxValue. Длина потока не превышает миллиарда чисел.</param>
        /// <param name="sortFactor">Фактор упорядоченности потока. Неотрицательное число.
        /// Если в потоке встретилось число x, то в нём больше не встретятся числа меньше, чем (x - sortFactor).</param>
        /// <param name="maxValue">Максимально возможное значение чисел в потоке. Неотрицательное число, не превышающее 2000.</param>
        /// <returns>Отсортированный по возрастанию поток чисел.</returns>
        static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue) {
            int indexFactor = 0;
            
            // Поиск позиции, до какой мы отберём все малые числа в последовательности
            var enumerable = inputStream.ToList();
            foreach (var e in enumerable) {
                if (e == sortFactor) {
                    indexFactor = enumerable.GetEnumerator().Current;
                    break;
                }
            }
            
            // Изменяем коллекциям свойство Capacity, чтобы
            // не тратить время на удвоение массива, если это будет необходимо
            List<int> lowers = new List<int> { Capacity = maxValue }; // для хранения всех малых чисел
            List<int> biggers = new List<int> { Capacity = maxValue }; // для запоминания позиций больших чисел
                                                                       // в меньшей половине
            
            // Сортировка методом вставки
            int j = 0;
            for (int i = 0; i < indexFactor; i++) {
                if (enumerable[i] < sortFactor) {
                    if (j == 0) {
                        lowers.Add(enumerable[i]);
                        j++;
                        continue;
                    }

                    int left = 0;
                    int right = j;
                    int index = 0;
                    while (true) {
                        index = (right + left) / 2; // центр
                        if (left >= right || lowers[j] == enumerable[i]) {
                            break;
                        }
                        else if (lowers[j] < enumerable[i]) {
                            left = index + 1;
                        }
                        else {
                            if (index != 0 && lowers[index - 1] < enumerable[i]) {
                                break;
                            }

                            right = index - 1;
                        }
                    }
                    lowers.Insert(index, enumerable[i]);
                }
                else {
                    biggers.Add(enumerable[i]);
                }
            }

            for (int i = indexFactor; i < enumerable.Count; i++) {
                biggers.Add(enumerable[i]);
            }
            
            // Сортировка методом экстремумов
            for (int i = 0; i < biggers.Count - 1; i++) {
                for (int k = i + 1; k < biggers.Count; k++) {
                    if (biggers[i] > biggers[k]) {
                        (biggers[i], biggers[k]) = (biggers[k], biggers[i]);
                    }
                }
            }
            foreach (var i in biggers) lowers.Add(i);

            //IEnumerable<int> output = lowers;
            return lowers;
        }
    }
}