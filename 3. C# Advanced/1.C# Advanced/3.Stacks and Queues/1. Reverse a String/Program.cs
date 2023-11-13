using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Reverse_a_String
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            while(stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
