using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Unique_Usernames
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                names.Add(Console.ReadLine());
            }

            Console.WriteLine(String.Join(Environment.NewLine, names));
        }
    }
}
