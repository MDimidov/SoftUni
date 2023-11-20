//////WITH METHOD\\\\\\\

//List<string> strings = new();
//int n = int.Parse(Console.ReadLine());

//for (int i = 0; i < n; i++)
//{
//    strings.Add(Console.ReadLine());
//}

//string item = Console.ReadLine();
//Console.WriteLine(CountBiggerElemets(item, strings));



//static int CountBiggerElemets<T>(T element, List<T> items) where T : IComparable<T>
//{
//    int count = 0;
//    foreach(T item in items)
//    {
//        if(item.CompareTo(element) > 0)
//        {
//            count++;
//        }
//    }

//    return count;
//}



//////WITH CLASS\\\\\\\
using System;
using GenericCountMethodStrings;

Box<string> items = new();
int n = int.Parse(Console.ReadLine());

for(int i = 0; i < n; i++)
{
    items.Add(Console.ReadLine());
}

string item = Console.ReadLine();

Console.WriteLine(items.Count(item));

