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

        private void Dfs(int wantedSum, ref int currSum, LinkedList<int> currPath, List<List<int>> result, Tree<int> tree)
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
            throw new NotImplementedException();
        }
    }
}
