using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Basic_Stack_Operations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int n = input[0];
            int numberToPop = input[1];
            int findElement = input[2];

            Stack<int> stack = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Take(n)
                .ToArray());

            for(int i = 0; i < numberToPop; i++)
            {
                stack.Pop();
            }

            if(!stack.Any())
            {
                Console.WriteLine(0);
            }
            else if(stack.Contains(findElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
