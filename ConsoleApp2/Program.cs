
using System;
using System.Collections.Generic;
using System.Collections;


namespace LinkedList
{


    public class DoublyLinkedList<T>
    {
        // private SortedSet<Minion> minions;


        public DoublyNode<T> head { get; set; }
        public DoublyNode<T> tail { get; set; }
        public int size { get; set; }

        public DoublyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.size = 0;
        }


        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (size == 0)
            {
                tail = node;
                head = node;
            }
            else
            {
                if (head.Next == null)
                {
                    head.Next = node;
                    tail = node;
                    tail.Previous = head;
                }
                else
                {
                    tail.Next = node;
                    node.Previous = tail;
                    tail = node;
                }
            }

            size++;
        }

        public void AddLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            if (size == 0)
            {
                head = node;
            }
            else
            {
                tail.Next = node; // делаем резервное место под след значение
                node.Previous = tail; // кидаем указатель хвоста на пред элемент перед добавленым
            }

            tail = node; // новый конец списка
            size++;
        }

        public T RemoveFirst()
        {
            T removedData = head.data;
            if (size != 0)
            {
                head = head.Next;

                if (size == 0)
                {
                    tail = null;
                }
                else
                {
                    head.Previous = null;
                }
            }

            size--;
            return removedData;
        }

        public T RemoveLast()
        {
            T removedData = tail.data;
            switch (size)
            {
                case 0:
                    return removedData;
                case 1:
                    head = tail = null;
                    break;
                default:
                    tail.Previous.Next = null;
                    tail = tail.Previous;
                    break;
            }

            size--;
            return removedData;
        }

        public void ClearAll() // очистка всего списка
        {
            head = null;
            tail = null;
            size = 0;
        }


        public void Replace(T oldItem, T newItem) // замена определенного элемента
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.data.Equals(oldItem))
                {
                    current.data = newItem;
                }

                current = current.Next;
            }
        }

        public void ReplaceLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.data = data;
            }
        } // замена в конце

        public void ReplaceFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                head.data = data;
            }
        }

        public T RemoveAt(int index)
        {
            if (index > size || index < 0)
                throw new ArgumentOutOfRangeException();
            T removedData;
            if (index == 0)
                removedData = RemoveFirst();
            else if (index == (size - 1))
                removedData = RemoveLast();
            else
            {
                DoublyNode<T> current = head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }

                removedData = current.data;
                current.Next = current.Next.Next;
                size--;
            }

            return removedData;

        } // удаление по индексу начиная с 0.

        public T Get(int index)
        {
            if (index < this.size)
            {
                var node = this.head;
                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }

                return node.data;
            }

            throw new InvalidOperationException();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0) throw new ArgumentOutOfRangeException();
                DoublyNode<T> current = head;
                for (int i = 0; i < index; i++)
                {
                    if (current.Next == null)
                        throw new ArgumentOutOfRangeException();
                    current = current.Next;
                }

                return current.data;
            }
        }



        public class DoublyNode<T>
        {
            public DoublyNode(T data)
            {
                this.data = data;
            }

            public T data { get; set; }
            public DoublyNode<T> Previous { get; set; }
            public DoublyNode<T> Next { get; set; }
        }
    }



    public class Minion
    {
        private int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        private static int count = 0;

        public Minion()
        {
            this.Id = ++count;
            this.Name = " ";
            this.Age = 1;

        }

        public Minion(string name)
        {
            this.Id = ++count;
            this.Name = name;
            this.Age = 1;
        }

        public Minion(string name, int age)
        {
            this.Id = ++count;
            this.Name = name;
            this.Age = age;
        }

        public override string ToString()
        {
            return $"id: {Id}, {Name} {Age}";
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            var m1 = new Minion();
            m1.Name = "DIMA";
            m1.Age = 20;

            var m2 = new Minion();
            m2.Name = "PASHA";
            m2.Age = 19;

            var m3 = new Minion();
            m3.Name = "MAKAR";
            m3.Age = 21;


            var linkedList = new DoublyLinkedList<Minion>();
            linkedList.AddFirst(m1);
            linkedList.AddFirst(m2);
            linkedList.AddLast(m3);
            for (int i = 0; i < linkedList.size; i++)
            {
                Console.WriteLine(linkedList[i]);
            }
        }
    }

}
