// Task Description:
// Calculate Sequence with a Queue
//We are given the following sequence of numbers:
//•	S1 = N
//•	S2 = S1 + 1
//•	S3 = 2 * S1 + 1
//•	S4 = S1 + 2
//•	S5 = S2 + 1
//•	S6 = 2 * S2 + 1
//•	S7 = S2 + 2
//•	…
//Using the Queue<T> class, write a program to print its first 50 members for given N. Examples:
//Input | Output
//    2   |	2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, …
//    -1  |	-1, 0, -1, 1, 1, 1, 2, …
//1000    |	1000, 1001, 2001, 1002, 1002, 2003, 1003, …



Problem03.Queue.Queue<int> ints = new();

int n = int.Parse(Console.ReadLine()!);

ints.Enqueue(n);

for (int i = 1; i < 50; i++)
{
    int s = ints.Peek();
    Console.Write(ints.Dequeue() + ", ");
    ints.Enqueue(s + 1);
    ints.Enqueue(2 * s + 1);
    ints.Enqueue(s + 2);
}

while (ints.Any())
{
    Console.Write(ints.Dequeue() + (ints.Any() ? ", " : ""));
}