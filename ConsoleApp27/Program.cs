
namespace MyNamespace
{


    public class Consumer
    {
        private Semaphore _producerSemaphore;
        private Semaphore _consumerSemaphore;
        private Queue<Work> _queue;

        public Consumer(ref Semaphore producerSemaphore, ref Semaphore consumerSemaphore, ref Queue<Work> queue)
        {
            _producerSemaphore = producerSemaphore;
            _consumerSemaphore = consumerSemaphore;
            _queue = queue;
        }

        public void DoWork()
        {
            _consumerSemaphore.WaitOne();
            Work work;
            lock (Program.LockObject)
            {
                work = _queue.Dequeue();
            }

            
            Thread.Sleep(work.TimeToDo);
            
            _producerSemaphore.Release();
        }
    }



    public class Producer
    {
        private Semaphore _producerSemaphore;
        private Semaphore _consumerSemaphore;
        private Queue<Work> _queue;

        public Producer(ref Semaphore producerSemaphore, ref Semaphore consumerSemaphore, ref Queue<Work> queue)
        {
            _producerSemaphore = producerSemaphore;
            _consumerSemaphore = consumerSemaphore;
            _queue = queue;
        }

        public void CreateWork(object? obj)
        {
            _producerSemaphore.WaitOne();
            var work = (Work)obj;
            lock (Program.LockObject)
            {
                _queue.Enqueue(work);
            }

            
            _consumerSemaphore.Release();
        }
    }



    public class Work
    {
        public string Title { get; set; }
        public int TimeToDo { get; set; }

        public Work(string title, int timeToDo)
        {
            Title = title;
            TimeToDo = timeToDo;
        }

        public override string ToString()
        {
            return $"Title: {Title}, TimeToDo: {TimeToDo}";
        }
    }

    class Program
    {
        public static object LockObject = new object();

        static void Main(string[] args)
        {

            var producerSemaphore = new Semaphore(2, 2);
            var consumerSemaphore = new Semaphore(0, 2);
            var queue = new Queue<Work>();

            var producer1 = new Producer(ref producerSemaphore, ref consumerSemaphore, ref queue);
            var producerThread1 = new Thread(new ParameterizedThreadStart(producer1.CreateWork));
            producerThread1.Start(new Work("Wash", 1000));

            var producer2 = new Producer(ref producerSemaphore, ref consumerSemaphore, ref queue);
            var producerThread2 = new Thread(new ParameterizedThreadStart(producer2.CreateWork));
            producerThread2.Start(new Work("Clean", 5000));

            var producer3 = new Producer(ref producerSemaphore, ref consumerSemaphore, ref queue);
            var producerThread3 = new Thread(new ParameterizedThreadStart(producer3.CreateWork));
            producerThread3.Start(new Work("Eat", 2000));

            var consumer1 = new Consumer(ref producerSemaphore, ref consumerSemaphore, ref queue);
            var consumerThread1 = new Thread(new ThreadStart(consumer1.DoWork));
            consumerThread1.Start();

            var consumer2 = new Consumer(ref producerSemaphore, ref consumerSemaphore, ref queue);
            var consumerThread2 = new Thread(new ThreadStart(consumer2.DoWork));
            consumerThread2.Start();

            var consumer3 = new Consumer(ref producerSemaphore, ref consumerSemaphore, ref queue);
            var consumerThread3 = new Thread(new ThreadStart(consumer3.DoWork));
            consumerThread3.Start();
        }

    }
}
