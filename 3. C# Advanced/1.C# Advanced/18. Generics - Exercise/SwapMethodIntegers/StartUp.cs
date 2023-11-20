using SwapMethodIntegers;
using System;

int count = int.Parse(Console.ReadLine());
Box<int> box = new();


for(int i = 0; i < count; i++)
{
    int item = int.Parse(Console.ReadLine());
    box.Add(item);
}

int[] swapIndexes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

box.SwapIndexes(swapIndexes[0], swapIndexes[1]);
Console.WriteLine(box.ToString());