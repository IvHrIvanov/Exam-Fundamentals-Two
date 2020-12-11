using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vechicle> vechicle = new List<Vechicle>();

            int n = int.Parse(Console.ReadLine());
            int fuelMax = 75;
            for (int i = 0; i < n; i++)
            {
                string[] inputCar = Console.ReadLine().Split("|");
                string car = inputCar[0];
                int mielege = int.Parse(inputCar[1]);
                int fuel = int.Parse(inputCar[2]);

                Vechicle newCar = new Vechicle(car, mielege, fuel);
                vechicle.Add(newCar);
            }

            string[] command = Console.ReadLine().Split(" : ");

            while (command[0] != "Stop")
            {
                StringBuilder sb = new StringBuilder();
                string curCommand = command[0];
                string car = command[1];
                int index = vechicle.FindIndex(x => x.Car == car);
                if (curCommand == "Drive")
                {
                    int distance = int.Parse(command[2]);
                    int fuel = int.Parse(command[3]);

                    if (vechicle[index].Fuel >= fuel)
                    {
                        vechicle[index].Mileage += distance;
                        vechicle[index].Fuel -= fuel;
                        sb.Append($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    else
                    {
                        sb.Append("Not enough fuel to make that ride");
                    }             
                }
                else if (curCommand == "Refuel")
                {
                    int fuel = int.Parse(command[2]);
                    int carFuelTank = vechicle[index].Fuel;
                    int addetFuel = fuelMax - carFuelTank;

                    if (fuel + carFuelTank > fuelMax)
                    {
                        vechicle[index].Fuel += addetFuel;
                        sb.Append($"{car} refueled with {addetFuel} liters");
                    }
                    else
                    {
                        vechicle[index].Fuel += fuel;
                        sb.Append($"{car} refueled with {fuel} liters");
                    }

                }
                else if (curCommand=="Revert")
                {

                    int km = int.Parse(command[2]);
                    vechicle[index].Mileage -= km;
                    
                    if(vechicle[index].Mileage<10000)
                    {
                        vechicle[index].Mileage = 10000;
                    }
                    else
                    {
                        sb.Append($"{car} mileage decreased by {km} kilometers");
                    }

                }
                if (sb.Length > 0)
                {
                    Console.WriteLine(sb);
                }
                if (vechicle[index].Mileage >= 100000)
                {
                    Console.WriteLine($"Time to sell the {car}!");
                    vechicle.Remove(vechicle[index]);
                }
                command = Console.ReadLine().Split(" : ");

            }
            foreach (var item in vechicle.OrderByDescending(m=>m.Mileage).ThenBy(n=>n.Car))
            {
                Console.WriteLine($"{item.Car} -> Mileage: {item.Mileage} kms, Fuel in the tank: {item.Fuel} lt.");

            }
        }
    }
    class Vechicle
    {
        public Vechicle(string car, int mileage, int fuel)
        {
            Car = car;
            Mileage = mileage;
            Fuel = fuel;
        }

        public string Car { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}
