namespace DataStructure.Tree.Models
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        private TreeNode<T> _root;

        public TreeNode<T> Get(T value)
        {
            return _root?.Get(value);
        }

        public void Remove(T value)
        {
            _root = Remove(_root, value);
        }

        private TreeNode<T> Remove(TreeNode<T> subTreeRoot, T value)
        {
            if (subTreeRoot == null) return null;

            int compareTo = value.CompareTo(subTreeRoot.Value);

            if (compareTo < 0)
            {
                subTreeRoot.Left = Remove(subTreeRoot.Left, value);
            }
            else if (compareTo > 0)
            {
                subTreeRoot.Right = Remove(subTreeRoot.Right, value);
            }
            else
            {
                if(subTreeRoot.Left == null)
                {
                    return subTreeRoot.Right;
                }

                if(subTreeRoot.Right == null)
                {
                    return subTreeRoot.Left;
                }

                subTreeRoot.Value = subTreeRoot.Right.Min().Value;
                subTreeRoot.Right = Remove(subTreeRoot.Right, subTreeRoot.Value);
            }

            return subTreeRoot;
        }

        public TreeNode<T> Min()
        {
            return _root.Min();
        }

        public TreeNode<T> Max()
        {
            return _root.Max();
        }

        public void Insert(T value)
        {
            if (_root is null)
                _root = new TreeNode<T>(value);
            else _root.Insert(value);
        }

        public IEnumerable<T> TraverseInOrder()
        {
            if (_root is null)
                return Enumerable.Empty<T>();

            return _root.TraverseInOrder();
        }
    }
}
