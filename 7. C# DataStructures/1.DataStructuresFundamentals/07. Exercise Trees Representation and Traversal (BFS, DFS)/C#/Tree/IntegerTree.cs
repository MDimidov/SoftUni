namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTree : Tree<int>, IIntegerTree
    {
        public IntegerTree(int key, params Tree<int>[] children)
            : base(key, children)
        {
        }

        // DFS
        public IEnumerable<IEnumerable<int>> GetPathsWithGivenSum(int sum)
        {
            var result = new List<List<int>>();

            var currPath = new LinkedList<int>();
            currPath.AddFirst(Key);

            int currSum = Key;

            Dfs(sum, ref currSum, currPath, result, this);

            return result;
        }

        private void Dfs(
            int wantedSum,
            ref int currSum,
            LinkedList<int> currPath,
            List<List<int>> result,
            Tree<int> tree)
        {
            foreach (var child in tree.Children)
            {
                currSum += child.Key;
                currPath.AddLast(child.Key);
                Dfs(wantedSum, ref currSum, currPath, result, child);
            }

            if (currSum == wantedSum)
            {
                result.Add(new List<int>(currPath));
            }

            currSum -= tree.Key;
            currPath.RemoveLast();
        }

        public IEnumerable<Tree<int>> GetSubtreesWithGivenSum(int sum)
        {
            var result = new List<Tree<int>>();
            var allSubtrees = GetAllNodesBfs();

            foreach (var subtree in allSubtrees)
            {
                if (HasGivenSum(subtree, sum))
                {
                    result.Add(subtree);
                }
            }

            return result;
        }

        private bool HasGivenSum(Tree<int> subtree, int wantedSum)
        {
            int actualSum = subtree.Key;
            DfsGetSubtreeSum(subtree, ref actualSum, wantedSum);

            return actualSum == wantedSum;
        }

        private void DfsGetSubtreeSum(Tree<int> subtree, ref int actualSum, int wantedSum)
        {
            foreach (var tree in subtree.Children)
            {
                actualSum += tree.Key;
                DfsGetSubtreeSum(tree, ref actualSum, wantedSum);
            }
        }

        private IEnumerable<Tree<int>> GetAllNodesBfs()
        {
            var result = new List<Tree<int>>();
            var queue = new Queue<Tree<int>>();

            queue.Enqueue(this);

            while (queue.Any())
            {
                var currNode = queue.Dequeue();
                result.Add(currNode);

                foreach (var child in currNode.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

    }
}
