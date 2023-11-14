using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Key_Revolver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrel = int.Parse(Console.ReadLine());

            Stack<int> bullets = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Queue<int> lockers = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            int totalMoney = int.Parse(Console.ReadLine());

            int totalShoots = 0;
            while(lockers.Any() && bullets.Any())
            {
                if(bullets.Pop() <= lockers.Peek())
                {
                    lockers.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                if(++totalShoots % gunBarrel == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                }
            }
            int moneyEarned = totalMoney - totalShoots * bulletPrice;
            if (lockers.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {lockers.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${moneyEarned}");
            }
        }
    }
}
