namespace SymbolTable.Sequential.Model
{
    public class LinearSymbolTable<TKey, TValue>
    {
        private class Node
        {
            public TKey Key { get; }
            public TValue Value { get; }

            public Node Next { get; set; }

            public Node(TKey key, TValue value, Node next)
            {
                Key = key;
                Value = value;
                Next = next;
            }
        }

        private IEqualityComparer<TKey> _comparer;

        public LinearSymbolTable()
        {
            _comparer = EqualityComparer<TKey>.Default;
        }

        public LinearSymbolTable(IEqualityComparer<TKey> equalityComparer)
        {
            _comparer = equalityComparer ?? throw new ArgumentNullException(nameof(equalityComparer));
        }

        private Node _head;

        private int _size = 0;
        private int _version = 0;

        public int Count => _size;
        public bool IsEmpty => _size == 0;

        public void Add(TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            if (_head == null)
            {
                _head = new Node(key, value, default);
            }
            else
            {
                Node node = _head;

                while (node != null)
                {
                    if (_comparer.Equals(key, node.Key)) throw new InvalidOperationException();

                    node = node.Next;
                }

                _head = new Node(key, value, _head);
            }

            _size++;
            _version++;
        }

        public bool Remove(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            if (_head == null) throw new ArgumentNullException("List is emptry");

            Node node = _head;
            Node previous = default;

            while (node != null)
            {
                if (_comparer.Equals(key, node.Key))
                {
                    if (previous == null)
                        _head = default;
                    else
                        previous.Next = node.Next;

                    _size--;
                    _version++;

                    return true;
                }

                previous = node;
                node = node.Next;
            }

            return false;
        }

        public void TryGet(TKey key, out TValue value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            if (_head == null) throw new ArgumentNullException("List is emptry");

            if (_head == null)
            {
                value = _head.Value; return;
            }
            else
            {
                Node node = _head;

                while (node != null)
                {
                    if (_comparer.Equals(key, node.Key))
                    {
                        value = node.Value;

                        return;
                    }

                    node = node.Next;
                }
            }

            value = default;
        }

        public IEnumerable<TKey> Keys()
        {
            Node node = _head;

            int version = _version;

            while (node != null)
            {
                if (_version != version)
                    throw new InvalidOperationException();

                yield return node.Key;
            }
        }
    }
}
