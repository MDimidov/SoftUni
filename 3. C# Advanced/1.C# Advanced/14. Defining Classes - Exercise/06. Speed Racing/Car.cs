using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    internal class Car
    {
        //fields
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        //constructors
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer) 
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }


        //properties
        public string Model { get { return model; } set { model = value; } }
        public double FuelAmount { get { return fuelAmount; } set { fuelAmount = value; } }
        public double TravelledDistance { get { return travelledDistance; } set { travelledDistance = value; } }
        public double FuelConsumptionPerKilometer { get { return fuelConsumptionPerKilometer;} set { fuelConsumptionPerKilometer = value; } }

        //methods
        public void RideCar(string carModel, double amountOfKm) 
        {
            double neededFuel = this.fuelConsumptionPerKilometer * amountOfKm;
            if (neededFuel > this.fuelAmount)
            {
                Console.WriteLine($"Insufficient fuel for the drive");
                return;
            }
            this.travelledDistance += amountOfKm;
            this.fuelAmount -= neededFuel;
        }
    }
}
