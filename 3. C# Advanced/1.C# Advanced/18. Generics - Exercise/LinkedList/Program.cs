using CustomDoublyLinkedList;

//CustomList customList = new();

//customList.Add(1);
//customList.Add(2);
//customList.Add(3);
//customList.Add(4);
//customList.Add(5);

////Console.WriteLine(customList.Count);
////Console.WriteLine(customList[2]);


////Console.WriteLine();
////Console.WriteLine(customList.RemoveAt(3));
////Console.WriteLine(customList.Count);

//customList.Insert(1, 55);
//Console.WriteLine(customList[1]);
//Console.WriteLine(customList.Count);
//Console.WriteLine(customList.Contains(45));

//Console.WriteLine(customList[0]);
//Console.WriteLine(customList[1]);
//Console.WriteLine(customList[2]);
//Console.WriteLine(customList[3]);
//Console.WriteLine(customList[4]);
//Console.WriteLine(customList[5]);

//customList.Swap(1, 3);
//Console.WriteLine();
//Console.WriteLine(customList[0]);
//Console.WriteLine(customList[1]);
//Console.WriteLine(customList[2]);
//Console.WriteLine(customList[3]);
//Console.WriteLine(customList[4]);
//Console.WriteLine(customList[5]);


CustomList<string> customList = new();

customList.Add("Myro");
customList.Add("Joro");
customList.Add("Ivan");
customList.Add("Stoyan");
customList.Add("Preso");
customList.Add("Ceco");

//Console.WriteLine(customList.Count);
//Console.WriteLine(customList[2]);


//Console.WriteLine();
//Console.WriteLine(customList.RemoveAt(3));
//Console.WriteLine(customList.Count);

customList.Insert(1, "Captain");
Console.WriteLine(customList[1]);
Console.WriteLine(customList.Count);
Console.WriteLine(customList.Contains("Preso"));

Console.WriteLine(customList[0]);
Console.WriteLine(customList[1]);
Console.WriteLine(customList[2]);
Console.WriteLine(customList[3]);
Console.WriteLine(customList[4]);
Console.WriteLine(customList[5]);

customList.Swap(1, 3);
Console.WriteLine();
Console.WriteLine(customList[0]);
Console.WriteLine(customList[1]);
Console.WriteLine(customList[2]);
Console.WriteLine(customList[3]);
Console.WriteLine(customList[4]);
Console.WriteLine(customList[5]);
