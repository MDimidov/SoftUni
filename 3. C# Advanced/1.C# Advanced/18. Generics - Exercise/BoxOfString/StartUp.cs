using BoxOfString;

int count = int.Parse(Console.ReadLine());
Box<string> box = new();


for(int i = 0; i < count; i++)
{
    string item = Console.ReadLine();
    box.Add(item);
}

Console.WriteLine(box.ToString());