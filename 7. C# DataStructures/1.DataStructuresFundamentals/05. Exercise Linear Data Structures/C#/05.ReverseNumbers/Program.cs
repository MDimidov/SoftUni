var nums = Console.ReadLine()!
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse);

Stack<int> stack = new();
foreach (var num in nums)
{
    stack.Push(num);
}

while (stack.Any())
{
    Console.Write(stack.Pop() + " ");
}