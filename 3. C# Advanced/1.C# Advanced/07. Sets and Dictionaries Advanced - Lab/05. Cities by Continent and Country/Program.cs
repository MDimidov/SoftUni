using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Cities_by_Continent_and_Country
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var continentsDic = new Dictionary<string, Dictionary<string, List<string>>>();

            for(int i = 0; i < n; i++)
            {
                string[] continentInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string continent = continentInfo[0];
                string country = continentInfo[1];
                string city = continentInfo[2];

                if (!continentsDic.ContainsKey(continent))
                {
                    continentsDic[continent] = new Dictionary<string, List<string>>();
                }
                if (!continentsDic[continent].ContainsKey(country))
                {
                    continentsDic[continent][country] = new List<string>();
                }
                continentsDic[continent][country].Add(city);
            }

            foreach(var(continent, countries) in continentsDic)
            {
                Console.WriteLine(continent + ":");
                foreach(var(country, cities) in countries)
                {
                    Console.WriteLine($"{country} -> {string.Join(", ", cities)}");
                }
            }
        }
    }
}
