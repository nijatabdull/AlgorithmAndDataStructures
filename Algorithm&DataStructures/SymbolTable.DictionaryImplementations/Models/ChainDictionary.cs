using SymbolTable.Sequential.Model;
using System.Collections;

namespace SymbolTable.DictionaryImplementations.Models
{
    public class ChainDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private int _size = 0;
        private int _version = 0;

        private const int DEFAULT_CAPACITY = 4;

        private LinearSymbolTable<TKey, TValue>[] _symbolTable;

        public ChainDictionary() : this(DEFAULT_CAPACITY) { }
        public ChainDictionary(int capacity)
        {
            Capacity = capacity;
            _symbolTable = new LinearSymbolTable<TKey, TValue>[Capacity];

            for (int i = 0; i < Capacity; i++)
            {
                _symbolTable[i] = new LinearSymbolTable<TKey, TValue>();
            }
        }

        public int Capacity { get; private set; }
        public int Count => _size;
        public bool IsEmpty => _size == 0;

        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % Capacity;
        }

        public void Add(TKey key, TValue value)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            if (Contains(key)) throw new InvalidOperationException("Key already exists");

            if (Count >= 10 * Capacity) Resize();

            int index = Hash(key);

            _symbolTable[index].Add(key, value);

            _size++;
            _version++;
        }

        public bool Contains(TKey key)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            int index = Hash(key);

            return _symbolTable[index].TryGet(key, out _);
        }

        public bool Remove(TKey key)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            int index = Hash(key);

            bool isRemoved = _symbolTable[index].Remove(key);

            _size--;
            _version++;

            return isRemoved;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (key is null) throw new ArgumentNullException(nameof(key));

            int index = Hash(key);

            return _symbolTable[index].TryGet(key, out value);
        }

        private void Resize()
        {
            Capacity *= 2;

            LinearSymbolTable<TKey, TValue>[] linearSymbolTable = new LinearSymbolTable<TKey, TValue>[Capacity];

            for (int i = 0; i < Capacity; i++)
            {
                linearSymbolTable[i] = new LinearSymbolTable<TKey, TValue>();
            }

            for (int i = 0; i < Capacity / 2; i++)
            {
                foreach (TKey item in _symbolTable[i].Keys())
                {
                    if (_symbolTable[i].TryGet(item, out TValue value))
                    {
                        linearSymbolTable[i].Add(item, value);
                    }
                }
            }

            _symbolTable = linearSymbolTable;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            int version = _version;
            for (int i = 0; i < _size; i++)
            {
                foreach (TKey item in _symbolTable[i].Keys())
                {
                    if (_version != version)
                    {
                        if (_symbolTable[i].TryGet(item, out TValue value))
                        {
                            yield return new KeyValuePair<TKey, TValue>(item, value);
                        }
                    }
                }
            }
        }

        public IEnumerable<TKey> Keys()
        {
            for (int i = 0; i < _size; i++)
            {
                foreach (TKey item in _symbolTable[i].Keys())
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
