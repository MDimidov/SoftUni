using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sets_of_Elements
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            int[] setsInputs = Console.ReadLine()
                .Split()
                .Select(x => int.Parse(x))
                .ToArray();

            for(int i = 0; i < setsInputs[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }
            for(int i = 0; i < setsInputs[1]; i++)
            {
                secondSet.Add(int.Parse(Console.ReadLine()));
            }

            //Method 1
            //foreach(int num1 in firstSet)
            //{
            //    foreach(int num2 in secondSet)
            //    {
            //        if(num1 == num2)
            //        {
            //            Console.Write(num1 + " ");
            //        }
            //    }
            //}

            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(' ', firstSet));
        }
    }
}
