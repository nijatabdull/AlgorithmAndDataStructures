using DataStructure.Node.Models;

namespace DataStructure.Stack.Model
{
    internal class StackByLinkedList<T>
    {
        private int _size = 0;
        private int _version = 0;

        private DoublyLinkedList<T> _linkedList;

        public int Count => _size;
        public bool IsEmpty => _size == 0;

        public StackByLinkedList()
        {
            _linkedList = new DoublyLinkedList<T>();
        }

        public void Push(T item)
        {
            _linkedList.AddLast(item);

            _size++;
            _version++;
        }

        public T Pop()
        {
            T value = _linkedList.RemoveLast();

            _size--;
            _version++; 

            return value;
        }

        public T Peek()
        {
            return _linkedList.Last.Value;
        }
    }
}
