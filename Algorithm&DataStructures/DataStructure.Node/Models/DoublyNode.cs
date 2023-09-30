namespace DataStructure.Node.Models
{
    internal class DoublyNode<T>
    {
        public DoublyNode<T> Next { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public T Value { get; set; }

        public DoublyNode()
        {
            
        }
        public DoublyNode(T value)
        {
            Value = value;
        }
    }
}
