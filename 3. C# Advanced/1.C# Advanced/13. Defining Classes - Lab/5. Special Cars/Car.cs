using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarManufacturer
{
    public class Car
    {
        //fields
        private string make = string.Empty;
        private string model = string.Empty;
        private int year = 0;
        private double fuelQuantity;
        private double fuelConsumption;

        private Engine engine;
        private Tire[] tires;

        //constructors
        public Car()
        {
            this.make = "VW";
            this.model = "Golf";
            this.year = 2025;
            this.fuelQuantity = 200;
            this.fuelConsumption = 10;
        }
        public Car(string make, string model, int year): this()
        {
            this.make = make;
            this.model = model;
            this.year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption): this(make, model,  year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires): this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }



        //properties
        public string Make { get { return make; } set { make = value; } }
        public string Model { get { return model; } set { model = value; } }
        public int Year { get { return year;} set { year = value; } }
        public double FuelQuantity { get { return fuelQuantity; } set { fuelQuantity = value; } }
        public double FuelConsumption { get { return fuelConsumption; } set { fuelConsumption = value; } }

        public Engine Engine { get { return engine; } set { engine = value; } }
        public Tire[] Tires { get { return tires; } set { tires = value; } }

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

        public string ShowSpecial()
        {
            StringBuilder result = new StringBuilder();

            double fuelNeededFor20km = 20 * this.fuelConsumption / 100.0;

            result.AppendLine($"Make: {this.Make}");
            result.AppendLine($"Model: {this.Model}");
            result.AppendLine($"Year: {this.Year}");
            result.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            result.AppendLine($"FuelQuantity: {this.FuelQuantity - fuelNeededFor20km}");

            return result.ToString().Trim();
        }
    }
}
