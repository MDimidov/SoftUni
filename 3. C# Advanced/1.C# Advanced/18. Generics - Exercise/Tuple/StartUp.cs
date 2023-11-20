using Tuple;
using System;

string[] name = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

string firstAndLastName = $"{name[0]} {name[1]}";
string address = name[2];
CustomTuple<string, string> tuple1 = new(firstAndLastName, address);

string[] nameLiters = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
CustomTuple<string, int> tuple2 = new(nameLiters[0], int.Parse(nameLiters[1]));

string[] intDouble = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

CustomTuple<int, double> tuple3 = new(int.Parse(intDouble[0]), double.Parse(intDouble[1]));

Console.WriteLine(tuple1);
Console.WriteLine(tuple2);
Console.WriteLine(tuple3);

