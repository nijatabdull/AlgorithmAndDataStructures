using System.Collections;

namespace Algorithm.Heap_Sort_.Model
{
    public class MaxHeap<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] _array;
        private int _size = 0;
        private int _version = 0;

        private static int DEFAULT_CAPACITY = 4;

        public MaxHeap(int capacity)
        {
            _array = new T[capacity];
        }

        public MaxHeap() : this(DEFAULT_CAPACITY) { }

        public int Count => _size;
        public int Capacity => _array.Length;
        public bool IsEmpty => _size == 0;

        public void Add(T item)
        {
            Resize();

            _array[_size] = item;

            Heapify(_size);

            _size++;
            _version++;
        }

        public T Peek()
        {
            if (IsEmpty) throw new ArgumentNullException();

            return _array[0];
        }

        public T Remove()
        {
            return Remove(0);
        }

        public T Remove(int index)
        {
            if (IsEmpty) throw new ArgumentNullException();

            T removalValue = _array[index];

            T lastValue = _array[_size - 1];
            _array[index] = lastValue;
            _array[_size - 1] = default;

            Heapify(index);
            ReverseHeapify(index);

            _size--;
            _version++;

            return removalValue;
        }

        private void ReverseHeapify(int index, int size = 0)
        {
            if (size == 0) size = _size;

            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;

            if (leftChildIndex > size - 1 || rightChildIndex > size - 1)
            {
                return;
            }

            T leftChild = _array[leftChildIndex];
            T rightChild = _array[rightChildIndex];

            int comparisonLeftChild = leftChild.CompareTo(_array[index]);
            int comparisonRightChild = rightChild.CompareTo(_array[index]);

            if (comparisonLeftChild > 0 && comparisonRightChild > 0)
            {
                int comparisonChild = leftChild.CompareTo(rightChild);

                if (comparisonChild > 0)
                {
                    Swap(_array, leftChildIndex, index);
                    ReverseHeapify(leftChildIndex, size);
                }
                else
                {
                    Swap(_array, rightChildIndex, index);
                    ReverseHeapify(rightChildIndex, size);
                }
            }
            else if(comparisonLeftChild > 0)
            {
                Swap(_array, leftChildIndex, index);
                ReverseHeapify(leftChildIndex, size);
            }
            else if (comparisonRightChild > 0)
            {
                Swap(_array, rightChildIndex, index);
                ReverseHeapify(rightChildIndex, size);
            }
            else
            {
                return;
            }
        }

        public void Sort()
        {
            int lastIndex = _size - 1;

            for (int i = lastIndex; i > 0; i--)
            {
                Swap(_array, 0, i);
                ReverseHeapify(0, i);
            }
        }

        private void Heapify(int index)
        {
            if (index < 1) return;

            int parent = (index - 1) / 2;

            T currentValue = _array[index];
            T parentValue = _array[parent];

            int comparison = currentValue.CompareTo(parentValue);

            if (comparison > 0)
            {
                Swap(_array, index, parent);
                Heapify(parent);
            }
        }

        private void Swap(T[] array, int index, int parent)
        {
            T temp = array[index];
            array[index] = _array[parent];
            array[parent] = temp;
        }

        private void Resize()
        {
            if (_size >= Capacity)
            {
                Array.Resize(ref _array, Capacity * 2);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int version = _version;
            for (int i = 0; i < _size; i++)
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
