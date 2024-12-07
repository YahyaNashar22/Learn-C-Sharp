namespace ClassesAndObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Access Modifiers: private - public - protected - internal


            Console.WriteLine("--------------------------------");
            Console.WriteLine("------Classes And Objects-------");
            Console.WriteLine("--------------------------------");

            Car firstCar = new Car("E500", "Mercedes", 1998, true);
            Vehicle vehicle  = new Vehicle(true);
            Cat puffy = new Cat();
            Turtle ten = new Turtle();


            firstCar.DisplayInfo();
            firstCar.Type = "test";
            firstCar.DisplayInfo();
            firstCar.Horn();
            firstCar.IsAvailable();
            firstCar.ChangeAvailability();
            firstCar.IsAvailable();

            Console.WriteLine(firstCar.ShowMe());
            Console.WriteLine(vehicle.ShowMe());

            firstCar.Drive();

            puffy.Eat();
            Animal.MakeSound();

            ten.Eat();
        }
    }
}
