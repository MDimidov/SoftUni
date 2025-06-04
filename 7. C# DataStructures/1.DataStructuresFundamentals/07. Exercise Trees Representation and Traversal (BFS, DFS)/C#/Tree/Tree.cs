namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private List<Tree<T>> children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.children = new List<Tree<T>>();
            Key = key;

            foreach (var child in children)
            {
                AddChild(child);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string AsString()
        {
            var sb = new StringBuilder();
            int indent = 0;

            DfsAsString(sb, this, indent);

            return sb.ToString().Trim();
        }

        private void DfsAsString(StringBuilder sb, Tree<T> tree, int indent)
        {
            sb.Append(' ', indent)
                .AppendLine(tree.Key.ToString());

            foreach (var child in tree.Children)
            {
                DfsAsString(sb, child, indent + 2);
            }
        }

        public IEnumerable<T> GetInternalKeys()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Any())
            {
                var currentNode = queue.Dequeue();
                if (currentNode.Children.Any() && currentNode.Parent != null)
                {
                    result.Add(currentNode.Key);
                }

                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public IEnumerable<T> GetLeafKeys()
        {
            var result = new List<T>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Any())
            {
                var currentNode = queue.Dequeue();
                if (!currentNode.Children.Any())
                {
                    result.Add(currentNode.Key);
                }

                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public T GetDeepestKey()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }

        private Tree<T> GetKeys()
        {

            return null;
        }
    }
}
