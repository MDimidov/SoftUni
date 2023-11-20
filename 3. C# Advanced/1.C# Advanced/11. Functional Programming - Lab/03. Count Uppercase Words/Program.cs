

Func<string, bool> isWordUpper = word => char.IsUpper(word[0]);

string[] inputArr = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Where(isWordUpper)
    .ToArray();

Console.WriteLine(String.Join(Environment.NewLine, inputArr));

