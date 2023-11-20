int n = int.Parse(Console.ReadLine());
List<Person> people = new List<Person>();

for(int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries);
    people.Add(new Person() { Name = input[0], Age = int.Parse(input[1]) });
}

string filterType = Console.ReadLine();
int filterAge = int.Parse(Console.ReadLine());

Func<Person, int, bool> filter = GetFilter(filterType);

people = people
    .Where(p => filter(p, filterAge))
    .ToList();

Action<Person> formatter = GetFormatter(Console.ReadLine());

foreach(Person person in people)
{
    formatter(person);
}


static Func<Person, int, bool> GetFilter(string filterType)
{
    if(filterType == "younger")
    {
        return (p, value) => p.Age < value;
    }
    return (p, value) => p.Age >= value;
}

static Action<Person> GetFormatter(string formatType)
{
    if(formatType == "name age")
    {
        return p => Console.WriteLine($"{p.Name} - {p.Age}");
    }
    if(formatType == "name")
    {
        return p => Console.WriteLine($"{p.Name}");
    }
    return p => Console.WriteLine(p.Age);
}







class Person
{
    public string Name;
    public int Age;
}