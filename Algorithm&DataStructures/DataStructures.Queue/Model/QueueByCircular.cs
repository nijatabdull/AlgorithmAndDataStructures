using System.Collections;
using System.Diagnostics;

namespace DataStructure.Queue.Model
{
    [DebuggerDisplay("Count = {Count}")]
    public class QueueByCircular<T> : IEnumerable<T>
    {
        private T[] _array;
        private int _size = 0;
        private int _version = 0;

        private int _head = 0;
        private int _tail = 0;

        public int Count => _size;
        public bool IsEmpty => _size == 0;
        public int Capacity => _array.Length;

        public QueueByCircular()
        {
            const int capacity = 4;
            _array = new T[capacity];
        }

        public QueueByCircular(int capacity)
        {
            _array = new T[capacity];
        }

        public void Enqueue(T item)
        {
            if (HasSpace() is false) Resize();

            if (_tail == _array.Length) _tail = 0;

            _array[_tail++] = item;

            _size++;
            _version++;
        }

        public T Dequeue()
        {
            T item = _array[_head];

            _array[_head++] = default;

            if (_head == _tail) _tail = 0;

            _size--;
            _version++;

            return item;
        }

        public T Peek()
        {
            return _array[_head];
        }

        public bool HasSpace() => _array.Length > _size;

        public void Resize()
        {
            T[] largerArray = new T[_size * 2];

            if (_head < _tail)
            {
                Array.Copy(_array, largerArray, _size);

                _head = 0;
                _tail = _size;
            }
            else
            {
                Array.Copy(_array, _head, largerArray, 0, _array.Length - _head);
                Array.Copy(_array, 0, largerArray, _array.Length - _head, _tail);

                _head = 0;
                _tail = _size;
            }

            _array = largerArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int version = _version;

            if (_head < _tail)
            {
                for (int i = 0; i < _size; i++)
                {
                    if (_version != version) throw new InvalidOperationException();
                    yield return _array[i];
                }
            }
            else
            {
                for (int i = _head; i < _array.Length; i++)
                {
                    if (_version != version) throw new InvalidOperationException();

                    yield return _array[i];
                }

                for (int i = 0; i < _tail; i++)
                {
                    if (_version != version) throw new InvalidOperationException();

                    yield return _array[i];
                }
            }
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
