using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class Stack<T> : IEnumerable<T>
    {
        private readonly int initialCapacity = 2;
        private T[] elements;

        public Stack()
        {
            this.elements = new T[initialCapacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T item)
        {
            if (this.Count == this.elements.Length)
            {
                Expand();
            }

            this.elements[this.Count] = item;
            this.Count++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return this.elements[this.Count - index - 1];
            }
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            T element = this.elements[this.Count - 1];
            this.elements[this.Count - 1] = default(T);
            this.Count--;
            return element;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Expand()
        {
            var newArray = new T[this.elements.Length * 2];
            for (int i = 0; i < elements.Length; i++)
            {
                newArray[i] = elements[i];
            }

            this.elements = newArray;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {



            var dima = new Stack<string>();

            dima.Push("Отчет");
            dima.Push("Стек");
            dima.Push("Дубровин");
            dima.Pop();


            Print(dima);

            static void Print<T>(Stack<T> stack)
            {
                foreach (var element in stack)
                {
                    Console.WriteLine(element);
                }
            }

        }
    }
}
