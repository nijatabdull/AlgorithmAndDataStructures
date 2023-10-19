namespace SymbolTable.BinarySearch.Model
{
    public class BinarySearchSt<TKey, TValue>
    {
        const int _defaultCapacity = 4;

        private TKey[] _keys;
        private TValue[] _values;

        private int _size = 0;
        private int _version = 0;

        public int Count => _size;
        public bool IsEmpty => _size == 0;

        private IComparer<TKey> _comparer;

        public BinarySearchSt() : this(_defaultCapacity, Comparer<TKey>.Default)
        {
        }

        public BinarySearchSt(int capacity) : this(capacity, Comparer<TKey>.Default)
        {

        }

        public BinarySearchSt(IComparer<TKey> comparer) : this(_defaultCapacity, comparer)
        {

        }

        public BinarySearchSt(int capacity, IComparer<TKey> comparer)
        {
            _comparer = comparer ?? throw new ArgumentNullException(nameof(comparer));

            _keys = new TKey[capacity];
            _values = new TValue[capacity];
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            Resize();

            int index = BinarySearch(key);

            if (index < _size && _comparer.Compare(_keys[index], key) == 0)
            {
                _values[index] = value; return;
            }

            for (int i = index; i < _size; i++)
            {
                _keys[i + 1] = _keys[i];
                _values[i + 1] = _values[i];
            }

            _keys[index] = key;
            _values[index] = value;

            _size++;
            _version++;
        }

        private void Resize()
        {
            if (_size == _keys.Length)
            {
                TKey[] keys = new TKey[_size * 2];
                TValue[] values = new TValue[_size * 2];

                for (int i = 0; i < _size; i++)
                {
                    keys[i] = _keys[i];
                    values[i] = _values[i];
                }

                _keys = keys;
                _values = values;
            }
        }

        public TValue GetValueByKey(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            int index = BinarySearch(key);

            if (index < _size && _comparer.Compare(_keys[index], key) == 0) return _values[index];

            return default;
        }

        public void Remove(TKey key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            int index = BinarySearch(key);

            for (int i = index; i < _size; i++)
            {
                _keys[i] = _keys[i + 1];
                _values[i] = _values[i + 1];
            }

            _keys[_size] = default;
            _values[_size] = default;

            _size--;
            _version++;
        }

        private int BinarySearch(TKey key)
        {
            int left = 0;
            int right = _size;

            while (left < right)
            {
                int mid = (left + right) / 2;

                if (_comparer.Compare(_keys[mid], key) == 0)
                {
                    return mid;
                }
                else if (_comparer.Compare(_keys[mid], key) > 0)
                    right = mid;
                else
                    left = mid + 1;
            }

            return left;
        }
    }
}
