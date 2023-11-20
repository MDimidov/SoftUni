using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.The_V_Logger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SortedDictionary<string, Vlogger> set = new SortedDictionary<string, Vlogger>();

            InicializeAndOperateWithVloggers(set);
            PrintVloggers(set);            
        }

        static void InicializeAndOperateWithVloggers(SortedDictionary<string, Vlogger> set)
        {
            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArg = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArg[1];
                string vloggerName = cmdArg[0];
                string followedVloggerName = cmdArg[2];

                //Vlogger vlogger = new Vlogger(vloggerName);
                if (command == "joined")
                {
                    if (!set.ContainsKey(vloggerName))
                    {
                        set.Add(vloggerName, new Vlogger(vloggerName));
                    }
                }
                else if (command == "followed")
                {
                    if (vloggerName != followedVloggerName
                        && set.ContainsKey(followedVloggerName)
                        && set.ContainsKey(vloggerName)
                        && !set[vloggerName].IsFollowingExist(followedVloggerName))
                    {
                        set[vloggerName].Following.Add(followedVloggerName);
                        set[followedVloggerName].Followers.Add(vloggerName);
                    }
                }
            }
        }
        static void PrintVloggers(SortedDictionary<string, Vlogger> set)
        {
            var sortSet = set
                .OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count);
            Console.WriteLine($"The V-Logger has a total of {set.Count} vloggers in its logs.");
            int i = 1;
            foreach (var (vloggerName, vloggerInfo) in sortSet)
            {
                Console.WriteLine(i++ + ". " + vloggerInfo.ToString()); // Print vlogger with his followers and following count

                // this print all followers only on the top vlogger
                if (i == 2 && vloggerInfo.Followers.Any())
                {

                    foreach (string follower in vloggerInfo.Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }

    public class Vlogger
    {
        public Vlogger(string name)
        {
            this.Name = name;
            this.Followers = new SortedSet<string>();
            this.Following = new HashSet<string>();
        }

        public string Name { get; set; }
        public SortedSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
        public bool IsFollowingExist(string name)
        {
            return this.Following.Contains(name);
        }

        public bool IsFollowerExist(string name)
        {
            return this.Followers.Contains(name);
        }

        public override string ToString()
        {
            int i = 1;
            return $"{this.Name} : {this.Followers.Count} followers, {this.Following.Count} following";
        }
    }
}
