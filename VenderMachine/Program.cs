namespace VenderMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int availableMoney = 1;
            bool userSelected = false;
            bool quit = false;
            int rcPrice = 3;
            int albeniPrice = 2;
            int cookiePrice = 4;
            int sandwichPrice = 5;
            int waterPrice = 1;
            int chipsPrice = 3;
            int selectedOption;


            while (!quit)
            {
                if (availableMoney > 0)
                {

                    Console.WriteLine("What would you like to purchase?");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"[1] RC {rcPrice}$");
                    Console.WriteLine($"[2] Albeni {albeniPrice}$");
                    Console.WriteLine($"[3] Cookie {cookiePrice}$");
                    Console.WriteLine($"[4] Sandwich {sandwichPrice}$");
                    Console.WriteLine($"[5] Water {waterPrice}$");
                    Console.WriteLine($"[6] Chips {chipsPrice}$");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine($"[7] Quit");


                    userSelected = int.TryParse(Console.ReadLine(), out selectedOption);



                    if (selectedOption < 1 || selectedOption > 7 || !userSelected)
                    {
                        Console.WriteLine("Invalid Input, Please Select a Number Form The Displayed Options!");
                    }

                    if (selectedOption == 1)
                    {
                        availableMoney -= rcPrice;
                        Console.WriteLine($"You have purchased an RC can for {rcPrice}$!");
                        Console.WriteLine($"Available Money is {availableMoney}");
                    }


                    if (selectedOption == 2)
                    {
                        availableMoney -= albeniPrice;
                        Console.WriteLine($"You have purchased an RC can for {albeniPrice}$!");
                        Console.WriteLine($"Available Money is {availableMoney}");
                    }


                    if (selectedOption == 3)
                    {
                        availableMoney -= cookiePrice;
                        Console.WriteLine($"You have purchased an RC can for {cookiePrice}$!");
                        Console.WriteLine($"Available Money is {availableMoney}");
                    }


                    if (selectedOption == 4)
                    {
                        availableMoney -= sandwichPrice;
                        Console.WriteLine($"You have purchased an RC can for {sandwichPrice}$!");
                        Console.WriteLine($"Available Money is {availableMoney}");
                    }


                    if (selectedOption == 5)
                    {
                        availableMoney -= waterPrice;
                        Console.WriteLine($"You have purchased an RC can for {waterPrice}$!");
                        Console.WriteLine($"Available Money is {availableMoney}");
                    }

                    if (selectedOption == 6)
                    {
                        availableMoney -= chipsPrice;
                        Console.WriteLine($"You have purchased an RC can for {chipsPrice}$!");
                        Console.WriteLine($"Available Money is {availableMoney}");
                    }

                    if (selectedOption == 7)
                    {
                        quit = true;
                    }
                }

                if (availableMoney == 0)
                {
                    Console.WriteLine("You ran out of money ! :(");
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("[1] Add Money?");
                    Console.WriteLine("[2] Quit");

                    userSelected = int.TryParse(Console.ReadLine(), out selectedOption);

                    if (selectedOption < 1 || selectedOption > 2 || !userSelected)
                    {
                        Console.WriteLine("Invalid Input, Please Select a Number Form The Displayed Options!");
                    }

                    if (selectedOption == 1)
                    {
                        availableMoney += 50;
                        Console.WriteLine(availableMoney);
                    }

                    if (selectedOption == 2)
                    {
                        quit = true;
                    }


                }
            }
            Console.ReadKey();
        }
    }
}
