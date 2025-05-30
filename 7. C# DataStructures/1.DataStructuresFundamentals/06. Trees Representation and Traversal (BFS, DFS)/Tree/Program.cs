namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            var subtree = new Tree<int>(36,
                               new Tree<int>(42),
                               new Tree<int>(3)
                               );

            var tree = new Tree<int>(34,
                        new Tree<int>(36,
                            new Tree<int>(42),
                                    new Tree<int>(3,
                                    new Tree<int>(78)
                                    )
                                ),
                                new Tree<int>(1),
                                new Tree<int>(103)
                            );

            //Console.WriteLine( string.Join(", ", subtree.OrderBfs()));
            Console.WriteLine( string.Join(", ", tree.OrderDfs()));

            tree.Swap(103, 42);

            Console.WriteLine( string.Join(", ", tree.OrderDfsRecursive()));

        }
    }
}
