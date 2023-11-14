using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Balanced_Parenthesis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char[] chars = Console.ReadLine()
                //.Split()
                .ToCharArray();

            Stack<char> stack = new Stack<char>();

            for(int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == ')')
                {
                    if (stack.Any() && chars[i] - 1 == stack.Peek())
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(chars[i]);
                    }
                }
                else
                {
                    if (stack.Any() && chars[i] - 2 == stack.Peek())
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(chars[i]);
                    }
                }
            }
            if (stack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
