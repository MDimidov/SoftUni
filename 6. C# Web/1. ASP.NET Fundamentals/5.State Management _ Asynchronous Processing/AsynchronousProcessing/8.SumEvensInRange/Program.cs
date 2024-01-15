namespace _8.SumEvensInRange;

internal class Program
{
    static void Main(string[] args)
    {
        string command;
        while ((command = Console.ReadLine()!) != "end")
        {
            if (command == "show")
            {
                long result = SumAsync();
                Console.WriteLine(result);
            }
        }
    }

    private static long SumAsync()
        => Task.Run(() =>
        {
            long sum = 0;
            for (long i = 1; i < 1000000000; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }).Result;
}
