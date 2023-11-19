using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.SoftUni_Party
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var partyList = new HashSet<string>();
            var vipList = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "PARTY")
            {
                if (input.Length == 8)
                {
                    if (char.IsNumber(input[0]))
                    {
                        vipList.Add(input);
                        continue;
                    }
                    partyList.Add(input);
                }
            }

            while ((input = Console.ReadLine()) != "END")
            {
                partyList.Remove(input);
                vipList.Remove(input);
            }

            Console.WriteLine(partyList.Count + vipList.Count);
            foreach(string reservation in vipList)
            {
                Console.WriteLine(reservation);
            }
            foreach (string reservation in partyList)
            {
                Console.WriteLine(reservation);
            }
        }
    }
}
