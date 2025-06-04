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
            => BfsWithResultKeys(tree => tree.Children.Any() && tree.Parent != null)
            .Select(tree => tree.Key);


        public IEnumerable<T> GetLeafKeys()
            => BfsWithResultKeys(tree => !tree.Children.Any())
            .Select(tree => tree.Key);


        public T GetDeepestKey()
            => GetDeepestNode().Key;

        private Tree<T> GetDeepestNode()
        {
            var leafs = BfsWithResultKeys(tree => !tree.Children.Any());
            int maxDepth = 0;

            Tree<T> deepestNode = null;
            foreach (var leaf in leafs)
            {
                int depth = GetDepth(leaf);
                if(depth > maxDepth)
                {
                    maxDepth = depth;
                    deepestNode = leaf;
                }
            }

            return deepestNode;
        }

        private int GetDepth(Tree<T> leaf)
        {
            int depth = 0;
            Tree<T> tree = leaf;

            while (tree.Parent != null)
            {
                depth++;
                tree = tree.Parent;
            }

            return depth;
        }

        public IEnumerable<T> GetLongestPath()
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Tree<T>> BfsWithResultKeys(Predicate<Tree<T>> predicate)
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Any())
            {
                var currentNode = queue.Dequeue();
                if (predicate.Invoke(currentNode))
                {
                    result.Add(currentNode);
                }

                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }
    }
}
