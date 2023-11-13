﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Matching_Brackets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stack = new Stack<int>();  

            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    int startIndex = stack.Pop();
                    Console.WriteLine(input.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
