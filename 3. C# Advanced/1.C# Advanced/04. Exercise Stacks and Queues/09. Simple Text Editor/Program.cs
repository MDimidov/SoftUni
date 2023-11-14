using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.Simple_Text_Editor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int n = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();

            for(int i = 0; i < n; i++) 
            {
                string[] cmdArg = Console.ReadLine()
                    .Split();
                string command = cmdArg[0];
                if(command == "1")
                {
                    stack.Push(stringBuilder.ToString());
                    string text = cmdArg[1];
                    stringBuilder.Append(text);
                }
                else if(command == "2")
                {
                    stack.Push(stringBuilder.ToString());
                    int count = int.Parse(cmdArg[1]);
                    stringBuilder.Remove(stringBuilder.Length - count, count) ;
                }
                else if(command == "3")
                {
                    int index = int.Parse(cmdArg[1]) - 1;
                    Console.WriteLine(stringBuilder[index]);
                }
                else if(command == "4")
                {
                    stringBuilder.Clear();
                    stringBuilder.Append(stack.Pop());
                    //Console.WriteLine(stringBuilder);
                }
            }
        }
    }
}
