using Algorithm.Heap_Sort_.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Diagnostics;

namespace Algorithm.Heap_Sort_.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class IndexController : ControllerBase
    {

        private readonly ILogger<IndexController> _logger;

        public IndexController(ILogger<IndexController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult HeapSort()
        {
            MaxHeap<int> maxHeap = new MaxHeap<int>();

            maxHeap.Add(7);
            maxHeap.Add(5);
            maxHeap.Add(2);
            maxHeap.Add(8);
            maxHeap.Add(3);
            maxHeap.Add(9);
            maxHeap.Add(4);
            maxHeap.Add(1);
            maxHeap.Add(6);
            maxHeap.Add(10);

            maxHeap.Sort();

            foreach (var item in maxHeap)
            {
                Debug.WriteLine(item);
            }

            return Ok();
        }

        [HttpGet]
        public IActionResult PriorityQueue()
        {
            PriorityQueue<string, int> priorityQueue = new PriorityQueue<string, int>();

            priorityQueue.Enqueue("Nicat", 1);
            priorityQueue.Enqueue("Hesen", 1);
            priorityQueue.Enqueue("Yusif", 1);
            priorityQueue.Enqueue("Tural", 2);
            priorityQueue.Enqueue("Ali", 2);
            priorityQueue.Enqueue("Yasin", 3);
            priorityQueue.Enqueue("Ruslan", 1);
            priorityQueue.Enqueue("Tofig", 1);

            string firstPeek = priorityQueue.Peek();
            string firstDequeue = priorityQueue.Dequeue();

            return Ok();
        }

        [HttpGet]
        public IActionResult ImmutableTest()
        {
            //first test
            ImmutableStack<int> imStack = ImmutableStack<int>.Empty;

            ImmutableStack<int> first = imStack.Push(1);
            ImmutableStack<int> second = first.Push(2);

            ImmutableStack<int> poped = second.Pop();

            bool zad1 = first.Equals(poped);
            bool zad2 = first == poped;

            //first test
            ImmutableList<int>.Builder ints = ImmutableList.CreateBuilder<int>();

            ints.Add(1);
            ints.Add(2);
            ints.Add(3);
            ints.Add(4);
            ints.Add(5);

            ImmutableList<int> immutableList = ints.ToImmutable();

            return Ok();
        }
    }
}