namespace CarRace__in_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Blixten McQeen", 120, 0);
            Car car2 = new Car("Rally Ragge", 120, 0);

            Thread t1 = new Thread(() => car1.Race(car1));
            Thread t2 = new Thread(() => car2.Race(car2));
            Thread t3 = new Thread(() => CurrentStatusRace.CurrentStatus()); 

            t3.IsBackground = true;

            t1.Start();
            t2.Start();
            t3.Start();





        }
    }
}
