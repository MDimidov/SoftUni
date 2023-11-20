namespace DefiningClasses;

public class StartUp
{
    private static void Main()
    {
        List<Car> cars = new();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] cmdArg = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = cmdArg[0];
            double fuelAmount = double.Parse(cmdArg[1]);
            double fuelConsumptionFor1km = double.Parse(cmdArg[2]);

            Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
            cars.Add(car);  

        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] drivenCar = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string carModel = drivenCar[1];
            double amountOfKm = double.Parse(drivenCar[2]);


            Car car = cars.Where(c => c.Model == carModel)
                .FirstOrDefault();
            car.RideCar(carModel, amountOfKm);
        }

        foreach(Car car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
        }
    }
}
