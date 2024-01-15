using System.Numerics;
using System.Runtime.CompilerServices;

namespace _9.SumEvensInBackground;

internal class Program
{
    static void Main(string[] args)
    {
        long sum = 0;

        Task task = Task.Run(() =>
        {
            sum = 0;
            for (long i = 0; i < 10000000; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
                Console.WriteLine(sum);
            }
        });

        while (true)
        {
            string line = Console.ReadLine()!;
            if (line == "exit")
            {
                return;
            }
            else if (line == "show")
            {
                Console.WriteLine("true");
            }
        }
    }
}
