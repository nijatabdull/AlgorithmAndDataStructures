namespace DataStructure.Stack.Model
{
    internal class StackByArray<T>
    {
        private int _version = 0;
        private int _size = 0;
        private int _capacity;

        private T[] _array;

        public StackByArray()
        {
            _capacity = 4;
            _array = new T[_capacity];
        }

        public int Count => _size;
        public bool IsEmpty => _size == 0;
        public int Capacity => _capacity;

        public void Push(T item)
        {
            if(HasSpace() is false) Resize();

            _array[_size] = item;

            _size++;
            _version++;
        }

        public T Pop()
        {
            T item = _array[--_size];

            _array[_size] = default;

            _version++;

            return item;
        }

        public T Peek()
        {
            return _array[--_size];
        }

        private bool HasSpace()
        {
            return _array.Length < _capacity;
        }

        private void Resize()
        {
            T[] temp = _array;
            _array = new T[_capacity * 2];

            Array.Copy(temp, _array, temp.Length);
        }
    }
}
