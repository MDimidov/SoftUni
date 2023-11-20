using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothesByColor = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                if (!clothesByColor.ContainsKey(color))
                {
                    clothesByColor[color] = new Dictionary<string, int>();
                }

                foreach(string clothes in input.Skip(1))
                {
                    if (!clothesByColor[color].ContainsKey(clothes))
                    {
                        clothesByColor[color][clothes] = 0;
                    }
                    clothesByColor[color][clothes]++;
                }
            }

            string[] findDress = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach(var (color, dresses) in clothesByColor)
            {
                Console.WriteLine($"{color} clothes:");
                foreach(var (dress, count) in dresses)
                {
                    string print = $"* {dress} - {count}";
                    if(color == findDress[0] && dress == findDress[1])
                    {
                        print += " (found!)";
                    }
                    Console.WriteLine(print);
                }
            }
        }
    }
}
