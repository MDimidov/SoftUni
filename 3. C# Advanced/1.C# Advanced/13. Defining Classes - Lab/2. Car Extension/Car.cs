using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    internal class Car
    {
        //fields
        private string make = string.Empty;
        private string model = string.Empty;
        private int year = 0;
        private double fuelQuantity;
        private double fuelConsumption;

        //properties
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year;} set { year = value; } }
        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }
        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }

        //methids
        public void Drive(double distance)
        {
            double neededFuel = distance * this.fuelConsumption;

            if(this.fuelQuantity - neededFuel > 0)
            {
                this.fuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine($"Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.AppendLine($"Fuel: {this.FuelQuantity:F2}");

            return result.ToString().Trim();
        }
    }
}
