using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.ForceBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var usersSides = new SortedDictionary<string, SortedSet<string>>();
            var usersDic = new Dictionary<string, string>();

            string input;
            while((input = Console.ReadLine()) != "Lumpawaroo")
            {
                string[] cmdArg = input
                    .Split(new string[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries);
                
                string forceSide = cmdArg[0];
                string forceUser = cmdArg[1];

                if(input.Contains(" -> "))
                {
                    forceUser = cmdArg[0];
                    forceSide = cmdArg[1];
                    if (usersDic.ContainsKey(forceUser))
                    {
                        usersSides[usersDic[forceUser]].Remove(forceUser);
                    }
                    if (!usersSides.ContainsKey(forceSide))
                    {
                        usersSides[forceSide] = new SortedSet<string>();
                    }
                    usersSides[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }
                if (!usersSides.ContainsKey(forceSide))
                {
                    usersSides[forceSide] = new SortedSet<string>();
                }

                if (!usersDic.ContainsKey(forceUser))
                {
                    usersDic[forceUser] = forceSide;
                    usersSides[forceSide].Add(forceUser);
                }
            }
            foreach(var (forceSide, forceUsers) in usersSides
                .OrderByDescending(x => x.Value.Count))
            {
                if (forceUsers.Any())
                {
                    Console.WriteLine($"Side: {forceSide}, Members: {forceUsers.Count}");
                    foreach(string forceUser in forceUsers)
                    {
                        Console.WriteLine($"! {forceUser}");
                    }
                }
            }
        }
    }
}
