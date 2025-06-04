namespace Demo
{
    using System;
    using Tree;

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = new string[]
               {
                "7 19", "7 21", "7 14", "19 1", "19 12", "19 31", "14 23", "14 6"
               };

            IntegerTreeFactory tree = new IntegerTreeFactory();
            tree.CreateTreeFromStrings(input);


        }
    }
}
