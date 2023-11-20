Func<string, int> parser = x => int.Parse(x);
Func<int[], int> countArray = x => x.Count();
Func<int[], int> sumArray = x => x.Sum();

int[] inputArr = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(parser)
    .ToArray();

Console.WriteLine(countArray(inputArr));
Console.WriteLine(sumArray(inputArr));