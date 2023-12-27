using System.Globalization;

namespace AnotherTest
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int[] inputArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new();

            foreach (int num in inputArr)
            {
                stack.Push(num);
            }

            for(int i = 0; i < inputArr.Length; i++)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
