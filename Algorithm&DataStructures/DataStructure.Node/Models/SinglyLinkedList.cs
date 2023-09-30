using System.Collections;

namespace DataStructure.Node.Models
{
    internal class SinglyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        private int _size;
        private int _version = 0;

        public int Count { get { return _size; } }

        public SinglyLinkedList()
        {
            _size = 0;
        }

        internal void Add(T item)
        {
            Node<T> newNode = new() { Value = item };

            if (_size == 0)
            {
                _head = _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }

            _size++;
            _version++;
        }

        internal void Remove(T item)
        {
            Node<T> node = _head;
            Node<T> previousNode = default;

            while (node != null)
            {
                if (item.Equals(node.Value))
                {
                    if (previousNode == null)
                    {
                        _head = node.Next;
                    }
                    else
                    {
                        previousNode.Next = node.Next;

                        if (node.Next is null)
                            _tail = previousNode;
                    }

                    _version--;
                    _size--;
                    break;
                }
                previousNode = node;
                node = node.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int version = _version;
            Node<T> node = _head;

            while (node != null)
            {
                if (_version != version)
                    throw new InvalidOperationException();

                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
