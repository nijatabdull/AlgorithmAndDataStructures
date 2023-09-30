namespace DataStructure.Node.Models
{
    internal class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
    }
}
