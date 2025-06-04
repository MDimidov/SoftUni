namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegerTreeFactory
    {
        private Dictionary<int, IntegerTree> nodesByKey;

        public IntegerTreeFactory()
        {
            this.nodesByKey = new Dictionary<int, IntegerTree>();
        }

        public IntegerTree CreateTreeFromStrings(string[] input)
        {
            foreach (string inputLine in input)
            {
                int[] keys = inputLine
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                int parent = keys[0];
                int child = keys[1];

                AddEdge(parent, child);
            }

            return GetRoot();
        }

        public IntegerTree CreateNodeByKey(int key)
        {
            if (!nodesByKey.ContainsKey(key))
            {
                nodesByKey.Add(key, new IntegerTree(key));
            }

            return nodesByKey[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = CreateNodeByKey(parent);
            var childNode = CreateNodeByKey(child);

            childNode.AddParent(parentNode);
            parentNode.AddChild(childNode);
        }

        public IntegerTree GetRoot()
        {
            foreach (var kvp in nodesByKey)
            {
                if (kvp.Value.Parent is null)
                {
                    return kvp.Value;
                }
            }

            return null;
        }
    }
}
