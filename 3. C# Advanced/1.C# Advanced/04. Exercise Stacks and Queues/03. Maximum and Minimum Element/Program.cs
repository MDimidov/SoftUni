using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Maximum_and_Minimum_Element
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            //string input;
            for(int i = 0; i < n; i++)
            {
                string[] cmdArg = Console.ReadLine()
                    .Split();
                string command = cmdArg[0];

                if(command == "1")
                {
                    int num = int.Parse(cmdArg[1]);
                    stack.Push(num);
                }
                else if(command == "2")
                {
                    stack.Pop();
                }
                else if (command == "3" && stack.Any())
                {
                    Console.WriteLine(stack.Max());
                }
                else if (command == "4" && stack.Any())
                {
                    Console.WriteLine(stack.Min());
                }
            }
            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
