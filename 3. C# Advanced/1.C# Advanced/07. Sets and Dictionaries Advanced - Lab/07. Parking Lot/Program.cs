using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Parking_Lot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            string input;
            while((input = Console.ReadLine()) != "END")
            {
                string[] cmdArg = input
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = cmdArg[0];
                string plate = cmdArg[1];

                if(direction == "IN")
                {
                    cars.Add(plate);
                }
                else if(direction == "OUT")
                {
                    cars.Remove(plate);
                }
            }

            if (!cars.Any())
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            foreach(string car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
