Func<double, double> addVAT = x => x * 1.2;
Func<string, double> parser = x => double.Parse(x);

Action<double> printer = x => Console.WriteLine($"{x:F2}");

double[] nums = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(parser)
    .Select(addVAT)
    .ToArray();

foreach(double num in nums)
{
    printer(num);
}


