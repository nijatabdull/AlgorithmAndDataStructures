using System.Collections;

namespace SymbolTable.DictionaryImplementations.Models
{
    public class LinearDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private int _size = 0;
        private int _version = 0;
        private TKey[] _keys;
        private TValue[] _values;
        private IEqualityComparer<TKey> _equalityComparer;

        private const int DEFAULT_CAPACITY = 4;

        public LinearDictionary() : this(DEFAULT_CAPACITY, EqualityComparer<TKey>.Default) { }
        public LinearDictionary(IEqualityComparer<TKey> equalityComparer) : this(DEFAULT_CAPACITY, equalityComparer) { }
        public LinearDictionary(int capacity) : this(capacity, EqualityComparer<TKey>.Default) { }
        public LinearDictionary(int capacity, IEqualityComparer<TKey> equalityComparer)
        {
            _keys = new TKey[capacity];
            _values = new TValue[capacity];
            _equalityComparer = equalityComparer;
        }

        public bool IsEmpty => _size == 0;
        public int Count => _size;
        public int Capacity => _keys.Length;

        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % Capacity;
        }

        public bool Contains(TKey key)
        {
            if (key is null) throw new ArgumentNullException("key");

            for (int i = Hash(key); _keys[i] != null; i = (i + 1) % Capacity)
            {
                if (key.Equals(_keys[i])) return true;
            }

            return false;
        }

        public TValue Get(TKey key)
        {
            if (key is null) throw new ArgumentNullException("key");

            for (int i = Hash(key); _keys[i] != null; i = (i + 1) % Capacity)
            {
                if (_keys[i].Equals(key)) return _values[i];
            }

            throw new ArgumentNullException("Key was not found");
        }

        public bool TryGet(TKey key, out int index)
        {
            if (key is null) throw new ArgumentNullException("key");

            for (int i = Hash(key); _keys[i] != null; i = (i + 1) % Capacity)
            {
                if (_keys[i].Equals(key))
                {
                    index = i;
                    return true;
                }
            }

            index = -1;

            return false;
        }

        public void Remove(TKey key)
        {
            if (key is null) throw new ArgumentNullException("key");

            if (TryGet(key, out int index) is false) return;

            _keys[index] = default(TKey);
            _values[index] = default(TValue);

            index = (index + 1) % Capacity;

            while (_keys[index] != null)
            {
                TKey keyToRehash = _keys[index];
                TValue valueToRehash = _values[index];

                _keys[index] = default(TKey);
                _values[index] = default(TValue);

                _size--;
                _version++;

                Add(keyToRehash, valueToRehash);

                index = (index + 1) % Capacity;
            }

            _size--;
            _version++;

            if (_size > 0 && _size <= Capacity / 8) Resize(Capacity / 2);
        }

        public void Add(TKey key, TValue value)
        {
            if (key is null) throw new ArgumentNullException("key");

            if (value is null)
            {
                Remove(key);
                return;
            }

            if (Count >= Capacity / 2)
            {
                Resize(2 * Capacity);
            }

            int i;

            for (i = Hash(key); _keys[i] != null; i = (i + 1) % Capacity)
            {
                if (key.Equals(_keys[i]))
                {
                    _values[i] = value;

                    _size++;
                    _version++;

                    return;
                }
            }
            _keys[i] = key;
            _values[i] = value;

            _size++;
            _version++;
        }

        public void Resize(int capacity)
        {
            LinearDictionary<TKey, TValue> keyValuePairs = new(capacity);

            for (int i = 0; i < Capacity; i++)
            {
                if (_keys[i] != null)
                {
                    keyValuePairs.Add(_keys[i], _values[i]);
                }
            }

            _keys = keyValuePairs._keys;
            _values = keyValuePairs._values;
        }

        public IEnumerable<TKey> Keys()
        {
            for (int i = 0; i < _size; i++)
            {
                if (_keys != null)
                    yield return _keys[i];
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            int version = _version;

            for (int i = 0; i < _size; i++)
            {
                if (_version != version) throw new InvalidOperationException();

                if (_keys[i] != null)
                {
                    TKey key = _keys[i];

                    TValue value = Get(key);

                    yield return new KeyValuePair<TKey, TValue>(key, value);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
