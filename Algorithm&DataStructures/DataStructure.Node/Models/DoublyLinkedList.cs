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
                if (node == doublyNode)
                {
                    IsFinded = true;
                    break;
                }

                node = node.Next;
            }

            if (IsFinded is false) return;

            DoublyNode<T> newDoublyNode = new DoublyNode<T>(value);

            if (node.Next is null) Last = newDoublyNode;

            newDoublyNode.Next = node.Next;
            node.Next = newDoublyNode;
            newDoublyNode.Previous = node;

            _size++;
            _version++;
        }

        public void AddBefore(DoublyNode<T> doublyNode, T value)
        {
            DoublyNode<T> doubly = First;
            bool isFinded = false;

            while (doubly != null)
            {
                if (doubly == doublyNode)
                {
                    isFinded = true;
                    break;
                }

                doubly = doubly.Next;
            }

            if (isFinded is false)
                return;

            DoublyNode<T> newDoublyNode = new DoublyNode<T>(value);

            newDoublyNode.Previous = doubly.Previous;

            if (doubly.Previous != null)
            {
                doubly.Previous.Next = newDoublyNode;

            }
            else
            {
                First = newDoublyNode;
            }

            newDoublyNode.Next = doubly;
            doubly.Previous = newDoublyNode;

            _size++;
            _version++;
        }

        public void Remove(DoublyNode<T> node)
        {
            DoublyNode<T> doublyNode = First;

            bool isFinded = false;

            while (doublyNode != null)
            {
                if (doublyNode == node) { isFinded = true; break; }

                doublyNode = doublyNode.Next;
            }

            if (isFinded is false) return;

            if (doublyNode.Next is null && doublyNode.Previous is null)
            {
                First = Last = null;
            }
            else if (doublyNode.Next is null)
            {
                doublyNode.Previous.Next = null;
                Last = doublyNode.Previous;
            }
            else if (doublyNode.Previous is null)
            {

                doublyNode.Next.Previous = null;
                First = doublyNode.Next;
            }
            else
            {
                doublyNode.Previous.Next = doublyNode.Next;
                doublyNode.Next.Previous = doublyNode.Previous;
            }


            _size--;
            _version++;
        }
    }
}
