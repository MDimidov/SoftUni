using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Product_Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var shops = new SortedDictionary<string, Dictionary<string, double>>();

            string input;
            while ((input = Console.ReadLine()) != "Revision") 
            {
                string[] shopInfo = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = shopInfo[0];
                string product = shopInfo[1];
                double price = double.Parse(shopInfo[2]);

                if(!shops.ContainsKey(shop))
                {
                    shops[shop] = new Dictionary<string, double>();
                }
                shops[shop].Add(product, price);
            }

            foreach(var(shop, products) in shops)
            {
                Console.WriteLine($"{shop}->");
                foreach(var (product, price) in products)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
