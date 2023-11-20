namespace DefiningClasses;
    public class StartUp
    {
        private static void Main()
        {
            Family family = new Family();
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++) 
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(input[0], int.Parse(input[1]));

                family.AddMember(person);
            }

            foreach(Person person in family.People
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
