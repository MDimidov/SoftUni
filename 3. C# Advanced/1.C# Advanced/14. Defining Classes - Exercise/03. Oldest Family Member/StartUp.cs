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

            Person oldest = family.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }
    }
