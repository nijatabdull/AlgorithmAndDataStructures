using DataStructure.Queue.Model;

namespace DataStructure.Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestArrayBasedQueue();

            //TestLinkedListBasedQueue();

            TestCircularBasedQueue();

            Console.ReadLine();
        }

        public static void TestArrayBasedQueue()
        {
            QueueByArray<int> queue = new QueueByArray<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);

            int data = queue.Peek();

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(queue.ToString());
        }

        public static void TestLinkedListBasedQueue()
        {
            QueueByLinkedList<int> queue = new QueueByLinkedList<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();

            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);

            int data = queue.Peek();

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(queue.ToString());
        }

        public static void TestCircularBasedQueue()
        {
            QueueByCircular<int> queue = new QueueByCircular<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);
            queue.Enqueue(10);

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            queue.Enqueue(11);
            queue.Enqueue(12);
            queue.Enqueue(13);

            int data = queue.Peek();

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(queue.ToString());
        }
    }
}