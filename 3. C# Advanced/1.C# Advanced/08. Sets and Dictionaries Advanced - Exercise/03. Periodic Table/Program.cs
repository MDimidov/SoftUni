using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Periodic_Table
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SortedSet<string> elements = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string[] elemetns = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for(int j = 0; j < elemetns.Length; j++)
                {
                    elements.Add(elemetns[j]);
                }
            }

            Console.WriteLine(String.Join(' ', elements));
        }
    }
}
