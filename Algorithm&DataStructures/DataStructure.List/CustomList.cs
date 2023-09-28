using System.Collections;

namespace DataStructure.List
{
    public class CustomList<T> : IEnumerable<T>
    {
        private T[] _array;

        private int _size = 0;
        private int _capacity;

        private int _version = 0;

        public int Capacity { get { return _capacity; } }
        public int Count { get { return _size; } }

        public CustomList()
        {
            _capacity = 4;
            _array = new T[_capacity];
        }

        public CustomList(int capacity) : this()
        {
              _capacity = capacity;
        }

        public void Add(T item)
        {
            if(CheckSpace() is false) Resize();

            _array[_size++] = item;

            _version++;
        }

        public void Remove(T item)
        {
            bool isDeleted = false;

            for (int i = 0; i < _size; i++)
            {
                if (_array[i] is not null && _array[i].Equals(item))
                {
                    _array[i] = default;
                    _size--;
                    _version++;
                    isDeleted = true;
                }

                if(isDeleted is true)
                {
                    _array[i] = _array[i + 1];
                }
            }
        }

        private bool CheckSpace()
        {
            return _size < _capacity;
        }

        private void Resize()
        {
            _capacity = 2 * _capacity;

            T[] newArray = new T[_capacity];

            Array.Copy(_array, 0, newArray, 0, _capacity / 2);

            _array = newArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
