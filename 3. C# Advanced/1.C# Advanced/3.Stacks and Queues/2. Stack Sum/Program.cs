using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2.Stack_Sum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var stack = new Stack<int>(
                Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray());

            OperateWithStack(stack);
            
            Console.WriteLine($"Sum: {stack.Sum()}");
        }

        static void OperateWithStack(Stack<int> stack)
        {
            string input;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdArg = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArg[0];
                if (command == "add")
                {
                    for (int i = 1; i < cmdArg.Length; i++)
                    {
                        stack.Push(int.Parse(cmdArg[i]));
                    }
                }
                else if (command == "remove")
                {
                    int count = int.Parse(cmdArg[1]);
                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }
        }
    }
}
