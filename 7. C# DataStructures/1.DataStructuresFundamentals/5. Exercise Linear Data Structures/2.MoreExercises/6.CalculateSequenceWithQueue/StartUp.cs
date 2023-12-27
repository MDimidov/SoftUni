using System.ComponentModel;

namespace test
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()!);

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);

            for (int i = 1; i <= 50; i++)
            {
                int s = queue.Dequeue();
                queue.Enqueue(s + 1);
                queue.Enqueue(2 * s + 1);
                queue.Enqueue(s + 2);

                if (i < 50)
                {
                    Console.Write(s + ", ");
                }
                else
                {
                    Console.Write(s);
                }
            }
        }
    }
}
