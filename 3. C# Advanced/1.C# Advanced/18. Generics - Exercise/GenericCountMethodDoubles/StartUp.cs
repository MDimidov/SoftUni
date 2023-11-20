
using System;
using GenericCountMethodStrings;

Box<double> items = new();
int n = int.Parse(Console.ReadLine());

for(int i = 0; i < n; i++)
{
    items.Add(double.Parse(Console.ReadLine()));
}

double item = double.Parse(Console.ReadLine());
Console.WriteLine(items.Count(item));

