using System.ComponentModel;

namespace test
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int[] nm = Console.ReadLine()!
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = nm[0];
            int m = nm[1];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);

            while (queue.Any())
            {
                int e = queue.Dequeue();
                queue.Enqueue(e + 1);
                queue.Enqueue(e + 2);
                queue.Enqueue(e * 2);

                if (n > m)
                {
                    Console.WriteLine("(no solution)");
                    return;
                }
                else if(e == m)
                {
                    Console.Write(e);
                    return;
                }
                else
                {
                    Console.Write(e + " -> ");
                }
            }
        }
    }
}
