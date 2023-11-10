using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Clock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for ( int i= 0; i < 24; i++)
            {
                for (int j= 0; j < 60; j++)
                {
                    Console.WriteLine($"{i}:{j}");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
