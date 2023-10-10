using DataStructure.Node.Models;
using System.Collections;

namespace DataStructure.Queue.Model
{
    public class QueueByLinkedList<T> : IEnumerable<T>
    {
        private int _size = 0;
        private int _version = 0;

        private DoublyLinkedList<T> doublyLinkedList;

        public int Count => _size;
        public bool IsEmpty => _size == 0;

        public QueueByLinkedList()
        {
            doublyLinkedList = new DoublyLinkedList<T>();
        }

        public void Enqueue(T item)
        {
            doublyLinkedList.AddLast(item);

            _size++;
            _version++;
        }

        public T Dequeue()
        {
            if (doublyLinkedList.First is null) throw new InvalidOperationException();

            T item = doublyLinkedList.RemoveFirst();

            _size--;
            _version++;

            return item;
        }

        public T Peek()
        {
            if (doublyLinkedList.First is null) throw new InvalidOperationException();

            return doublyLinkedList.First.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoublyNode<T> doublyNode = doublyLinkedList.First;

            while (doublyNode != null)
            {
                yield return doublyNode.Value;
                doublyNode = doublyNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
