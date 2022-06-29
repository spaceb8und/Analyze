using System;
using System.Collections.Generic;
using System.Threading;



namespace Parallel3
{
    public class Barber
    {
        private Semaphore _barberSemaphore;
        private Semaphore _queueSemaphore;
        private Queue<Visitor> _queue;

        public Barber(ref Semaphore barberSemaphore, ref Semaphore queueSemaphore, ref Queue<Visitor> queue)
        {
            _barberSemaphore = barberSemaphore;
            _queueSemaphore = queueSemaphore;
            _queue = queue;
        }

        public void DoHaircut()
        {
            while (true)
            {
                if (_barberSemaphore.WaitOne(TimeSpan.FromSeconds(10)))
                {
                    Visitor visitor;
                    lock (Visitor.LockObject)
                    {
                        visitor = _queue.Dequeue();
                    }

                    ConsoleHelper.WriteToConsole($"Visitor {visitor.Name} is getting a haircut");
                    Thread.Sleep(visitor.TimeToCut);
                    ConsoleHelper.WriteToConsole($"Visitor {visitor.Name} got a haircut and left");

                    _queueSemaphore.Release();

                    lock (Visitor.LockObject)
                    {
                        if (_queue.Count != 0) _barberSemaphore.Release();

                    }

                    continue;
                }

                break;
            }
        }
    }





    
        public static class ConsoleHelper
        {
            public static object LockObject = new object();

            public static void WriteToConsole(string info)
            {
                lock (LockObject)
                {
                    Console.WriteLine(info);
                }
            }
        }
    





    public class Visitor
    {
        public string Name;
        public int TimeToCut;
        private Semaphore _barberSemaphore;
        private Semaphore _queueSemaphore;
        private Queue<Visitor> _queue;
        public static Object LockObject = new Object();

        public Visitor(ref Semaphore barberSemaphore, ref Semaphore queueSemaphore, ref Queue<Visitor> queue,
            string name, int timeToCut)
        {
            Name = name;
            TimeToCut = timeToCut;
            _barberSemaphore = barberSemaphore;
            _queueSemaphore = queueSemaphore;
            _queue = queue;
        }

        public void VisitorMain()
        {
            if (_queueSemaphore.WaitOne(TimeSpan.FromSeconds(1)))
            {
                lock (LockObject)
                {
                    var isEmpty = _queue.Count == 0;
                    _queue.Enqueue(this);
                    ConsoleHelper.WriteToConsole(ToString() + " is in queue");
                    if (isEmpty)
                    {
                        _barberSemaphore.Release();
                    }
                }
            }
            else
            {
                ConsoleHelper.WriteToConsole(ToString() + " left");
            }
        }

        public override string ToString()
        {
            return $"Visitor: {Name}, {TimeToCut}";
        }

    }




    class Program
    {
        static void Main(string[] args)
        {
            var barberSemaphore = new Semaphore(0, 1);
            var queueSemaphore = new Semaphore(2, 2);

            var queue = new Queue<Visitor>();

            var barber = new Barber(ref barberSemaphore, ref queueSemaphore, ref queue);

            var visitor1 = new Visitor(ref barberSemaphore, ref queueSemaphore, ref queue, "Ivan", 2000);
            var visitor2 = new Visitor(ref barberSemaphore, ref queueSemaphore, ref queue, "Gosha", 3000);
            var visitor3 = new Visitor(ref barberSemaphore, ref queueSemaphore, ref queue, "Andrey", 5000);

            var visitorThread1 = new Thread(visitor1.VisitorMain);
            var visitorThread2 = new Thread(visitor2.VisitorMain);
            var visitorThread3 = new Thread(visitor3.VisitorMain);

            visitorThread1.Start();
            visitorThread2.Start();
            visitorThread3.Start();

            var barberThread = new Thread(barber.DoHaircut);
            barberThread.Start();
        }
    }
}
