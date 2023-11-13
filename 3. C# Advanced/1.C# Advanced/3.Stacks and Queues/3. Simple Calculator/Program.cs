using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Simple_Calculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>(
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Reverse());

            while(stack.Count > 1)
            {
                int x = int.Parse(stack.Pop());
                if(stack.Pop() == "+")
                {
                    x += int.Parse(stack.Pop());
                }
                else
                {
                    x -= int.Parse(stack.Pop());
                }
                stack.Push(x.ToString());
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
