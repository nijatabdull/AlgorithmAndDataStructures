namespace DataStructure.Tree.Models
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Value { get;  set; }
        public TreeNode<T> Left { get;  set; }
        public TreeNode<T> Right { get;  set; }

        public TreeNode(T value)
        {
            Value = value;
        }

        public void Insert(T value)
        {
            if (value is null)
                throw new ArgumentNullException("value");

            int comparision = Value.CompareTo(value);

            if (comparision == 0) return;

            if (comparision > 0)
            {
                if (Left == null)
                {
                    Left = new TreeNode<T>(value);
                }
                else
                {
                    Left.Insert(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = new TreeNode<T>(value);
                }
                else
                {
                    Right.Insert(value);
                }
            }
        }

        public TreeNode<T> Get(T value)
        {
            if (value is null)
                throw new ArgumentNullException("value");

            int comparision = Value.CompareTo(value);

            if (comparision == 0) return this;

            if (comparision > 0)
            {
                if (Left is not null)
                {
                    return Left.Get(value);
                }
            }
            else
            {
                if (Right is not null)
                {
                    return Right.Get(value);
                }
            }

            return default;
        }

        public TreeNode<T> Min()
        {
            if (Left == null)
                return this;
            return Left.Min();
        }

        public TreeNode<T> Max()
        {
            if (Right == null)
                return this;
            return Right.Max();
        }

        public IEnumerable<T> TraverseInOrder()
        {
            List<T> result = new();

            Traverse(result);

            return result;
        }

        private void Traverse(IList<T> list)
        {
            if (Left is not null)
                Left.Traverse(list);

            list.Add(Value);

            if (Right is not null)
                Right.Traverse(list);
        }
    }
}
