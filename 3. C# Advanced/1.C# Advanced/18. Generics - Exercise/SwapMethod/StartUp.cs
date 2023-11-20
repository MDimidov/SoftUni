using SwapMethod;
using System;

int count = int.Parse(Console.ReadLine());
Box<string> box = new();


for(int i = 0; i < count; i++)
{
    string item = Console.ReadLine();
    box.Add(item);
}

int[] swapIndexes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

box.SwapIndexes(swapIndexes[0], swapIndexes[1]);
Console.WriteLine(box.ToString());