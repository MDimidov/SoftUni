using BoxOfSInteger;

int count = int.Parse(Console.ReadLine());
Box<int> box = new();


for(int i = 0; i < count; i++)
{
    int item = int.Parse(Console.ReadLine());
    box.Add(item);
}

Console.WriteLine(box.ToString());