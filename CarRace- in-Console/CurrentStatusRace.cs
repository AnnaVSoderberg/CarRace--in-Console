using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace__in_Console
{
    internal class CurrentStatusRace
    {
        public static void CurrentStatus()
        {
            Console.WriteLine("For current status in this race print: yes and press Enter ");
            List<Car> cars = Car.GetAllCars();
            while (true)
            {
                var input = Console.ReadLine();
                if(input.ToLower() == "yes")
                {
                    foreach(var car in cars)
                    {
                        Console.WriteLine($"{car.Name} has driven {car.Distance} km of 10 000 and is at the speed {car.Speed} km/h");
                    }
                }
            }
        }
    }
}
