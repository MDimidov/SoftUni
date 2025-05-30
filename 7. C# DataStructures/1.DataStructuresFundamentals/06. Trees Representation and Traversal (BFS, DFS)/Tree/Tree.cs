namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T> : IAbstractTree<T>
    {
        private T value;
        private readonly List<Tree<T>> children;
        private Tree<T> parent;

        public Tree(T value)
        {
            this.value = value;
            children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.parent = this;
                this.children.Add(child);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> parent = GetNodeBfs(parentKey);

            if (parent == null)
            {
                throw new ArgumentNullException(nameof(parentKey));
            }

            parent.children.Add(child);
        }

        private Tree<T> GetNodeBfs(T nodeKey)
        {
            Queue<Tree<T>> tree = new Queue<Tree<T>>();

            tree.Enqueue(this);

            while (tree.Any())
            {
                var node = tree.Dequeue();

                if (node.value.Equals(nodeKey))
                {
                    return node;
                }

                foreach (var child in node.children)
                {
                    tree.Enqueue(child);
                }
            }

            return null;
        }

        public IEnumerable<T> OrderBfs()
        {
            Queue<Tree<T>> queue = new Queue<Tree<T>>();
            List<T> result = new List<T>();

            queue.Enqueue(this);

            while (queue.Any())
            {
                var subTree = queue.Dequeue();
                result.Add(subTree.value);

                foreach (var child in subTree.children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private void RecursiveDfs(Tree<T> node, ICollection<T> list)
        {
            foreach (var child in node.children)
            {
                RecursiveDfs(child, list);
            }

            list.Add(node.value);
        }

        public IEnumerable<T> OrderDfs()
        {
            Stack<T> result = new Stack<T>();
            Stack<Tree<T>> tree = new Stack<Tree<T>>();

            tree.Push(this);

            while (tree.Any())
            {
                var node = tree.Pop();

                foreach (var child in node.children)
                {
                    tree.Push(child);
                }

                result.Push(node.value);
            }

            return result;
        }

        public IEnumerable<T> OrderDfsRecursive()
        {
            List<T> result = new List<T>();
            RecursiveDfs(this, result);
            return result;
        }

        public void RemoveNode(T nodeKey)
        {
            if (this.value.Equals(nodeKey))
            {
                throw new ArgumentException(nameof(nodeKey));
            }

            var nodeToDelete = GetNodeBfs(nodeKey);

            if (nodeToDelete is null)
            {
                throw new ArgumentNullException(nameof(nodeKey));
            }

            nodeToDelete.parent.children.Remove(nodeToDelete);
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = GetNodeBfs(firstKey);
            var secondNode = GetNodeBfs(secondKey);

            if(firstNode is null || secondNode is null)
            {
                throw new ArgumentNullException();
            }

            var firstNodeParent = firstNode.parent;
            var secondNodeParent = secondNode.parent;

            if(firstNodeParent is null || secondNodeParent is null)
            {
                throw new ArgumentException();
            }

            int firstNodeIndex = firstNodeParent.children.IndexOf(firstNode);
            int secondNodeIndex = secondNodeParent.children.IndexOf(secondNode);

            firstNodeParent.children[firstNodeIndex] = secondNode;
            secondNodeParent.children[secondNodeIndex] = firstNode;
        }
    }
}
