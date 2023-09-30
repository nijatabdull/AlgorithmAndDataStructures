using DataStructure.Node.Models;

namespace DataStructure.Node
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();

            doublyLinkedList.AddLast(1);
            DoublyNode<int> doublyNode = doublyLinkedList.AddLast(2);
            doublyLinkedList.AddLast(3);

            doublyLinkedList.AddAfter(doublyNode, -1);

            //singly.Remove(6);

            //foreach (int i in singly)
            //{
            //    Console.WriteLine(i);
            //}

            Console.ReadKey();
        }

        private static void TestNode()
        {
            Node<int> node1 = new Node<int>();
            node1.Value = 1;

            Node<int> node2 = new Node<int> { Value = 2 };
            node1.Next = node2;

            Node<int> node3 = new Node<int> { Value = 3 };
            node2.Next = node3;

            Node<int> node4 = new Node<int> { Value = 4 };
            node3.Next = node4;

            while (node1 != null)
            {
                Console.WriteLine(node1.Value);
                node1 = node1.Next;
            }
        }
    }
}