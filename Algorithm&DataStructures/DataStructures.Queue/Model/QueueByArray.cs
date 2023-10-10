using System.Collections;

namespace DataStructure.Queue.Model
{
    public class QueueByArray<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _size = 0;
        private int _version = 0;

        private int _head = 0;
        private int _tail = 0;

        public int Count => _size;
        public bool IsEmpty => _size == 0;
        public int Capacity => _array.Length;

        public QueueByArray()
        {
            const int capacity = 4;
            _array = new T[capacity];
        }

        public QueueByArray(int capacity)
        {
            _array = new T[capacity];
        }

        public void Enqueue(T item)
        {
            if (HasSpace() is false) Resize();

            _array[_tail++] = item;

            _size++;
            _version++;
        }

        public T Dequeue()
        {
            if (_tail <= _head) throw new InvalidOperationException();

            T item = _array[_head];

            _array[_head++] = default;

            _size--;

            if (IsEmpty)
                _head = _tail = 0;

            _version++;

            return item;
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException();

            return _array[_head];
        }

        private bool HasSpace()
        {
            return _array.Length > _tail;
        }

        private void Resize()
        {
            if (_array.Length / 2 <= _head)
            {
                for (int i = 0; i < _head; i++)
                {
                    _array[i] = _array[i + _head];
                    _array[_head + i] = default;
                }

                _tail = _head;
                _head = 0;
            }
            else
            {
                T[] newArray = new T[_size * 2];

                Array.Copy(_array, newArray, _size);

                _array = newArray;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int version = _version;
            for (int i = _head; i < _tail; i++)
            {
                if (version != _version) throw new InvalidOperationException();
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
