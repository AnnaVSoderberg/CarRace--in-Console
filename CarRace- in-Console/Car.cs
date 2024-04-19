using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel.Design;

namespace CarRace__in_Console
{
    internal class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }

        public Car(string name, int speed, int distance)
        {
            Name = name;
            Speed = speed;
            Distance = distance;
        }

        public static List<Car> cars { get; set; } = new List<Car>();

        public static List<Car> GetAllCars()
        {
            return cars;
        }

        private static int totalcars;
        private static object lockObject = new object();

        public void Race(Car car)
        {   
            lock (lockObject)
            {
                cars.Add(car);
            }
            totalcars++;
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine($"\n\t\tTHIS RACE IS ON!\n\t {Name} is on the GO!\n");
            while (Distance <= 10000)
            {
                this.Distance += Speed;
                Thread.Sleep(1000);
                if ( sw.Elapsed.TotalSeconds > 30)
                {
                    HandleRandomEvent(car);
                    sw.Restart();
                }
            }
            lock (lockObject)
            {
                totalcars--;
                if (totalcars == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n\t THIS RACE HAS A WINNER!! \n\t\t{Name}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"\nBetter luck in next race {Name}! ");
                    Console.ResetColor();
                }
            }
        }

        public void HandleRandomEvent(Car car)
        {
            var rnd = new Random();
            var theRandom = rnd.Next(1, 51);

            if (theRandom == 1) // 1/50
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\t-->");
                Console.ResetColor();
                Console.WriteLine($"{Name} ran out of fuel! It will take 30 seconds to refuel");
                Thread.Sleep(30 * 1000);
            }
            else if(theRandom <= 3) // 2/50
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\t-->");
                Console.ResetColor();
                Console.WriteLine($"{Name} got a flat tire! It will take 20 seconds to change it");
                Thread.Sleep(20 * 1000);
            }
            else if (theRandom <= 8) // 5/50
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\t-->");
                Console.ResetColor();
                Console.WriteLine($"{Name} got a bird on the windsheald! It will take 10 secods to get it of");
                Thread.Sleep(10 * 1000);
            }
            else if (theRandom <= 18) // 10/50
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\t-->");
                Console.ResetColor();
                Speed -= 1;
                Console.WriteLine($"{Name} has engine problems! The speed will drop to {Speed} km/h");
            }
        }
    }
}
