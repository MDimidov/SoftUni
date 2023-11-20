Func<string, int> parser = x => int.Parse(x);
Func<int, bool> isEvenNum = x => x % 2 == 0;

int[] ints = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(parser)
    .Where(isEvenNum)
    .OrderBy(x => x)
    .ToArray();

Console.WriteLine(string.Join(", ", ints));