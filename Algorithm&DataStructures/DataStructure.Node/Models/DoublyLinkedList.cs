namespace DataStructure.Node.Models
{
    internal class DoublyLinkedList<T>
    {
        private int _size = 0;
        private int _version = 0;

        public int Count { get { return _size; } }
        public bool IsEmpty => _size == 0;

        public DoublyNode<T> First { get; set; }
        public DoublyNode<T> Last { get; set; }

        public DoublyNode<T> AddFirst(T item)
        {
            DoublyNode<T> newDoublyNode = new DoublyNode<T>(item);

            if (IsEmpty)
            {
                Last = newDoublyNode;
            }
            else
            {
                First.Previous = newDoublyNode;
                newDoublyNode.Next = First;
            }

            First = newDoublyNode;

            _size++;
            _version++;

            return newDoublyNode;
        }

        public DoublyNode<T> AddLast(T item)
        {
            DoublyNode<T> newDoublyNode = new DoublyNode<T>(item);

            if (IsEmpty)
            {
                First = newDoublyNode;
            }
            else
            {
                newDoublyNode.Previous = Last;
                Last.Next = newDoublyNode;
            }

            Last = newDoublyNode;

            _size++;
            _version++;

            return newDoublyNode;
        }

        public void AddAfter(DoublyNode<T> doublyNode, T value)
        {
            DoublyNode<T> node = First;
            bool IsFinded = false;

            while (node != null)
            {
                if(node == doublyNode)
                {
                    IsFinded = true;
                    break;
                }

                node = node.Next;
            }

            if (IsFinded is false) return;

            DoublyNode<T> newDoublyNode = new DoublyNode<T>(value);

            newDoublyNode.Next = node.Next;
            node.Next = newDoublyNode;
            newDoublyNode.Previous = node;

            _size++;
            _version++;
        }
    }
}
