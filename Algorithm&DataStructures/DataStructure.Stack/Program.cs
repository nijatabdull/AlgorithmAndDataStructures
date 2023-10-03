using DataStructure.Stack.Model;

namespace DataStructure.Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestStackByArray();

            TestStackByLinkedList();

            Console.ReadKey();
        }

        internal static void TestStackByArray()
        {
            StackByArray<int> stackByArray = new StackByArray<int>();

            stackByArray.Push(1);
            stackByArray.Push(2);
            stackByArray.Push(3);
            stackByArray.Push(4);
            stackByArray.Push(5);

            int val1 = stackByArray.Pop();
            int val2 = stackByArray.Peek();
        }

        internal static void TestStackByLinkedList()
        {
            StackByLinkedList<int> stackByArray = new StackByLinkedList<int>();

            stackByArray.Push(1);
            stackByArray.Push(2);
            stackByArray.Push(3);
            stackByArray.Push(4);
            stackByArray.Push(5);

            int val1 = stackByArray.Pop();
            int val2 = stackByArray.Peek();
        }
    }
}