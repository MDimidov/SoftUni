namespace _7.EvenNumbersThread;

internal class Program
{
    static void Main(string[] args)
    {
        int startNum = int.Parse(Console.ReadLine()!);
        int endNum = int.Parse(Console.ReadLine()!);

        Thread evens = new(() => PrintEvenNumbers(startNum, endNum));
        evens.Start();
        evens.Join();

        Console.WriteLine("Thread finish work");
    }
    private static void PrintEvenNumbers(int startNum, int endNum)
    {
        for(int i = startNum; i <= endNum; i++)
        {
            if(i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
