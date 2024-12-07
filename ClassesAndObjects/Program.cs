﻿namespace ClassesAndObjects
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

            firstCar.DisplayInfo();
            firstCar.Type = "test";
            firstCar.DisplayInfo();
            firstCar.Horn();
            firstCar.IsAvailable();
            firstCar.ChangeAvailability();
            firstCar.IsAvailable();
        }
    }
}
