namespace FunWithDictionariess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> persons = new Dictionary<string, string>();
            Console.WriteLine("----------------------------");
            Console.WriteLine("| Welcome To Dictionaries! |");
            Console.WriteLine("----------------------------");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("add <person>");
                Console.WriteLine("describe <person>");
                Console.WriteLine();

                string input = Console.ReadLine();
                var parts = input.Split(" ");

                if (parts[0] == "add")
                {
                    Console.WriteLine($"describe {parts[1]}:");
                    string description = Console.ReadLine();

                    persons.Add(parts[1], description);
                }

                if (parts[0] == "describe")
                {
                    if (!persons.TryGetValue(parts[1], out var person))
                    {
                        Console.WriteLine($"No description available for {parts[1]}");
                        continue;
                    }
                    Console.WriteLine($"{parts[1]} is {persons[parts[1]]}");
                }
            }
        }
    }
}
