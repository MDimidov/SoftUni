using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Truck_Tour
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int index = 0;
            Queue<PetrolStation> queue = new Queue<PetrolStation>();
            PetrolStation petrolStation;


            for (int i = 0; i < n; i++)
            {
                int[] petrolInfo = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                petrolStation = new PetrolStation(index, petrolInfo[0], petrolInfo[1]);
                queue.Enqueue(petrolStation);
                index++;
            }
            while (true)
            {
                int totalFuel = 0;
                Queue<PetrolStation> copyTrip = new Queue<PetrolStation>(queue);
                for(int i = 0; i < queue.Count; i++)
                {
                    petrolStation = copyTrip.Dequeue();
                    int fuel = petrolStation.Fuel;
                    int distance = petrolStation.Distane;
                    totalFuel += fuel;
                    if(distance > totalFuel)
                    {
                        break;
                    }
                    totalFuel -= distance;
                }

                if (!copyTrip.Any())
                {
                    Console.WriteLine(queue.Peek().Position);
                    return;
                }
                queue.Enqueue(queue.Dequeue());
            }
        }
    }
}

public class PetrolStation
{

    public PetrolStation(int index, int fuel, int distance) 
    {
        this.Position = index;
        this.Fuel = fuel;
        this.Distane = distance;
    }
    public int Position { get; set; }
    public int Fuel { get; set; }
    public int Distane { get; set; }

}
