using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> contentsPasswords = new Dictionary<string, string>();
            var usersPoints = new SortedDictionary<string, User>();

            CreateContests(contentsPasswords);
            InsertPoints(usersPoints, contentsPasswords);

            PrintResult(usersPoints);
        }

        static void PrintResult(SortedDictionary<string, User> usersPoints)
        {
            string bestUser = usersPoints
                .OrderByDescending(x => x.Value.Result.Values.Sum())
                .FirstOrDefault().Key;
            int maxPoints = usersPoints[bestUser].Result.Values.Sum();

            Console.WriteLine($"Best candidate is {bestUser} with total {maxPoints} points.\n" +
                $"Ranking:");
            foreach (var (username, userInfo) in usersPoints)
            {
                Console.WriteLine(username);
                foreach (var (contest, points) in userInfo
                    .Result
                    .OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
        static void InsertPoints(SortedDictionary<string, User> usersPoints, Dictionary<string, string> contentsPasswords)
        {
            string input;
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] cmdArg = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = cmdArg[0];
                string password = cmdArg[1];
                string username = cmdArg[2];
                int points = int.Parse(cmdArg[3]);

                if (contentsPasswords.ContainsKey(contest)
                    && contentsPasswords[contest] == password)
                {
                    if (!usersPoints.ContainsKey(username))
                    {
                        usersPoints[username] = new User(username);
                    }
                    usersPoints[username].Add(contest, points);
                }
            }
        }
        static void CreateContests(Dictionary<string, string> contentsPasswords)
        {
            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] cmdArg = input
                    .Split(':', StringSplitOptions.RemoveEmptyEntries);
                string contest = cmdArg[0];
                string password = cmdArg[1];

                contentsPasswords[contest] = password;
            }
        }
    }

    public class User
    {
        public User(string name)
        {
            this.Name = name;
            this.Result = new Dictionary<string, int>();
        }
        public string Name{ get; set;}
        public Dictionary<string, int> Result { get; set;}

        public void Add(string contest, int value)
        {
            if (!Result.ContainsKey(contest))
            {
                this.Result[contest] = value;
            }
            if (this.Result[contest] < value)
            {
                this.Result[contest] = value;
            }
        }

    }
}
