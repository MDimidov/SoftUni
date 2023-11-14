using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Fashion_Boutique
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());
            int racks = 0;
            int totolClotesInRack = 0;

            while(stack.Any())
            {
                int cuurClotes = stack.Pop();
                if (totolClotesInRack + cuurClotes < rackCapacity)
                {
                    totolClotesInRack += cuurClotes;
                }
                else if (totolClotesInRack + cuurClotes == rackCapacity)
                {
                    racks++;
                    totolClotesInRack = 0;
                }
                else if(totolClotesInRack + cuurClotes > rackCapacity)
                {
                    racks++;
                    totolClotesInRack = 0;
                    stack.Push(cuurClotes);
                }
            }
            if(totolClotesInRack > 0)
            {
                racks++;
            }
            Console.WriteLine(racks);
        }
    }
}
