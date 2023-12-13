using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Equal_Pairs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int maxDiff = int.MinValue;
            int diff = 0;
            int value1 = 0;
            int value2 = 0;

            for (int i = 1; i <= n * 2; i++)
            {
                int num = int.Parse(Console.ReadLine());
                value1 += num;

                if (i % 2 == 0)
                {
                    
                    if (i != 2)
                    {
                        diff = Math.Abs(value1 - value2);

                        if (maxDiff < diff)
                        {
                            maxDiff = diff;
                        }
                    }
                    value2 = value1;
                    value1 = 0;
                    
                }
                
            }
            
            if (maxDiff == 0 && diff == 0 || maxDiff == int.MinValue)
                Console.WriteLine($"Yes, value={value2}");
            else
                Console.WriteLine($"No, maxdiff={maxDiff}");
        }
    }
}
