using System.ComponentModel.Design;

namespace TemperatureConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string divider = "----------";
            string? choice = "";
            double? temperature;
            Console.WriteLine(divider + divider + divider + divider);
            Console.WriteLine($"{divider} Temperature Converter {divider}");

            while (choice != "3")
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Convert Fahrenheit to Celsius");
                Console.WriteLine("2. Convert Celsius to Fahrenheit");
                Console.WriteLine("3. Exit");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter The Temperature in Fahrenheit:");
                        temperature = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"{temperature} Fahrenheit is equal to {(temperature - 32) / 1.8} Celsius");
                        break;

                    case "2":
                        Console.WriteLine("Enter The Temperature in Celsius:");
                        temperature = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"{temperature} Celsius is equal to {(temperature * 1.8) + 32} Fahrenheit ");
                        break;

                    default:
                        Console.WriteLine("Enter a valid choice from the list");
                        break;

                }
            }

            Console.WriteLine("Come Back Any Time!");



        }
    }
}
