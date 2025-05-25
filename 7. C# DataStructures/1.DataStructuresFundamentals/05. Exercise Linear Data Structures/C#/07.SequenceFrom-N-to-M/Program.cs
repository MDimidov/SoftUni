// Sequence N  M
//We are given numbers n and m, and the following operations:
//a)	n  n + 1
//b)	n  n + 2
//c)	n  n * 2
//Write a program that finds the shortest sequence of operations from the list above that starts from n and finishes in m. If several shortest sequences exist, find the first one of them. 
//Examples:
//Input Output
//3 10	3 -> 5 -> 10
//5 -5	(no solution)
//10 30	10 -> 11 -> 13 -> 15 -> 30
//Hint: use a queue and the following algorithm:
//1.create a queue of numbers
//2.	queue  n
//3.	while (queue not empty)
//1.	queue  e
//2.	if (e < m) 
//i.	queue  e + 1
//ii.	queue  e + 2
//iii.	queue  e * 2
//3.	if (e == m) Print-Solution; exit
//The above algorithm either will find a solution, or will find that it does not exist. It cannot print the numbers comprising the sequence n  m.
//To print the sequence of steps to reach m, starting from n, you will need to keep the previous item as well. Instead using a queue of numbers, use a queue of items. Each item will keep a number and a pointer to the previous item. The algorithms changes like this:
//Algorithm Find-Sequence (n, m):
//1.create a queue of items { value, previous item }
//2.queue  { n, null }
//3.  while (queue not empty)
//1.queue  item
//2.	if (item.value < m) 
//i.	queue  { item.value + 1, item }
//ii.queue  { item.value + 2, item }
//iii.queue  { item.value * 2, item }
//3.  if (item.value == m) Print - Solution; exit
//Algorithm Print-Solution (item):
//1.  while (item not null)
//1.print item.value
//2.item = item.previous

// Method 1
//int[] input = Console.ReadLine()!
//    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
//    .Select(int.Parse)
//    .ToArray();

//int n = input[0];
//int m = input[1];

//Stack<int> stack = new Stack<int>();

//stack.Push(m);

//while (n < m)
//{

//    if (m / 2 >= n && m % 2 == 0)
//    {
//        m /= 2;
//    }
//    else if (m - 2 >= n)
//    {
//        m -= 2;
//    }
//    else if (n <= m - 1)
//    {
//        m -= 1;
//    }

//    stack.Push(m);
//}

//while (stack.Any())
//{
//    Console.Write(stack.Pop() + (stack.Any() ? " -> " : ""));
//}


// Method 2

int[] input = Console.ReadLine()!
    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int n = input[0];
int m = input[1];

if (m < n)
{
    Console.WriteLine("(no solution)");
    return;
}


Problem03.Queue.Queue<Node<int>> queue = new();
queue.Enqueue(new Node<int>(n, null));

while (queue.Any())
{
    Node<int> currentNode = queue.Dequeue();
    if(currentNode.Value == m)
    {
        PrintNodes(currentNode);
        break;
    }

    if(currentNode.Value < m)
    {
        queue.Enqueue(new Node<int>(currentNode.Value + 1, currentNode));
        queue.Enqueue(new Node<int>(currentNode.Value + 2, currentNode));
        queue.Enqueue(new Node<int>(currentNode.Value * 2, currentNode));
    }
}

void PrintNodes(Node<int> currentNode)
{
    Node<int>? node = currentNode;
    Stack<int> stack = new();

    while(node != null)
    {
        stack.Push(node.Value);
        node = node.Previous;
    }

    Console.WriteLine(string.Join(" -> ", stack));
}

public class Node<T>
{
    public Node(T value, Node<T>? previous)
    {
        Previous = previous;
        Value = value;
    }

    public Node<T>? Previous { get; set; }
    public T Value { get; set; }
}
