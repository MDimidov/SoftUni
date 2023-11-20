

////List<int> ren = new();


//using System.Linq;

//LinkedList<int> linkedList = new();
//linkedList.AddFirst(1);
//linkedList.AddFirst(2);
//linkedList.AddFirst(3);
//linkedList.AddFirst(4);
//linkedList.AddFirst(5);

//linkedList.AddLast(6);
//linkedList.AddLast(7);
//linkedList.AddLast(8);
//linkedList.AddLast(9);
//linkedList.AddLast(10);

//LinkedListNode<int> node = linkedList.Last;

//while (node != null)
//{
//    Console.WriteLine(node.Value);
//    node = node.Previous;
//}


///////////////////////////////////
//LinkedList<int> stack = new();

//stack.AddFirst(1);
//stack.AddFirst(2);
//stack.AddFirst(3);


//while(stack.Count() > 0)
//{
//    Console.WriteLine(stack.First.Value);
//    stack.RemoveFirst();
//}

///////////////////////////////////
//using Implementing_Linked_List;

//Node node = new(1);
//Node node1 = new(2);
//Node node2 = new(3);
//Node node3 = new(4);
//Node node4 = new(5);
//Node node5 = new(6);

//node.Next = node1;
//node1.Next = node2;
//node2.Next = node3;
//node3.Next = node4;
//node4.Next = node5;

//Node current = node;

//while(current != null)
//{
//    Console.WriteLine(current.Value);
//    current = current.Next;
//}
/////////////////////////////////////////


using Implementing_Linked_List;

SoftUniLinkedList softUniLinkedList = new();

softUniLinkedList.AddLast(1);
softUniLinkedList.AddLast(2);
softUniLinkedList.AddLast(3);
softUniLinkedList.AddLast(4);
softUniLinkedList.AddLast(5);
softUniLinkedList.AddLast(6);

softUniLinkedList.AddFirst(51);

int[] arr = softUniLinkedList.ToArray();
Console.WriteLine(String.Join(", ", arr));

softUniLinkedList.RemoveFirst();
softUniLinkedList.RemoveLast();

Node node = softUniLinkedList.Head;

//while(node != null)
//{
//    Console.WriteLine(node.Value);
//    node = node.Next;
//}

softUniLinkedList.ForEach(x => Console.WriteLine($"Node: {x}"));