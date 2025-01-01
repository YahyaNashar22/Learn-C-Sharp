namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            List<int> close = new List<int>();
            List<int> notClose = new List<int>();
            List<int> hangInThere = new List<int>();

            bool gameStart = false;
            bool success = false;
            bool validInput;

            string userInput;

            int enteredNumber;
            int randomNumber = 100;
            int correctPlaces = 0;
            int wrongPlaces = 0;
            int maxRows;

            while (true)
            {



                while (!gameStart && !success)
                {

                    Console.WriteLine("Welcome to the number guessing game!");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("");

                    Console.WriteLine("The Rules are as follow:");
                    Console.WriteLine("");

                    Console.WriteLine("* The Game will generate a random 3 digits number");
                    Console.WriteLine("* For each guess you make you're either in the 'Not Close', 'Close' or 'Hang in There' categories");
                    Console.WriteLine("* Not Close:\t\tNone of the chosen digits  match");
                    Console.WriteLine("* Close:\t\tAt least one digit matches, but it is not in the correct place");
                    Console.WriteLine("* Hang in There:\tAt least one digit matches, and in the correct place");
                    Console.WriteLine("* You win when you guess the correct number");
                    Console.WriteLine("");

                    Console.WriteLine("Press Enter to Start The Game!");


                    var key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        success = false;
                        //randomNumber = random.Next(100, 999);
                        randomNumber = 232;
                        gameStart = true;
                    }
                    else
                    {
                        Console.Clear();
                    }
                }


                while (gameStart && !success)
                {
                    Console.WriteLine();
                    Console.WriteLine("What's your guess?");
                    Console.WriteLine();

                    Console.WriteLine("Close   |   Not Close   |   Hang in There");
                    Console.WriteLine("--------+---------------+-----------------");

                    maxRows = Math.Max(close.Count, Math.Max(notClose.Count, hangInThere.Count));

                    for (int i = 0; i < maxRows; i++)
                    {
                        string closeValue = i < close.Count ? close[i].ToString() : "";
                        string notCloseValue = i < notClose.Count ? notClose[i].ToString() : "";
                        string hangInThereValue = i < hangInThere.Count ? hangInThere[i].ToString() : "";

                        Console.WriteLine($"{closeValue,-7} | {notCloseValue,-13} | {hangInThereValue,-15}");

                    }


                    userInput = Console.ReadLine();
                    if (userInput.Length != 3)
                    {
                        Console.WriteLine("Enter a valid guess of 3 digits");
                    }

                    validInput = int.TryParse(userInput, out enteredNumber);

                    if (validInput && userInput.Length == 3)
                    {
                        correctPlaces = 0;
                        wrongPlaces = 0;
                        string randomNumberStr = Convert.ToString(randomNumber);
                        for (int i = 0; i < 3; i++)
                        {
                            if (userInput[i] == randomNumberStr[i])
                            {
                                correctPlaces++;
                            }
                            else if (userInput.Contains(randomNumberStr[i]))
                            {
                                wrongPlaces++;
                            }
                        }
                        if (correctPlaces == 3)
                        {
                            success = true;
                            gameStart = false;
                        }
                        else if (correctPlaces > 0)
                        {
                            hangInThere.Add(enteredNumber);
                        }
                        else if (wrongPlaces > 0 && correctPlaces == 0)
                        {
                            close.Add(enteredNumber);
                        }
                        else if (wrongPlaces == 0)
                        {
                            notClose.Add(enteredNumber);
                        }
                    }


                }

                while (success && !gameStart)
                {
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("CONGRATULATIONS! YOU GUESSED THE RIGHT NUMBER!");
                    Console.WriteLine($"              {randomNumber}                 ");
                    Console.WriteLine("----------------------------------------------");

                    Console.WriteLine();
                    Console.WriteLine("Play Again?");
                    Console.WriteLine();
                    Console.WriteLine("[Y] - start again");
                    Console.WriteLine("[N] - exit");

                    userInput = Console.ReadLine();

                    if (userInput == "y" || userInput == "Y")
                    {
                        close.Clear();
                        notClose.Clear();
                        hangInThere.Clear();

                        enteredNumber = 0;
                        correctPlaces = 0;
                        wrongPlaces = 0;
                        maxRows = 0;

                        Console.Clear();

                        success = false;
                        gameStart = false;

                    }
                    else if (userInput == "n" || userInput == "N")
                    {
                        Console.WriteLine("Come Play Again When You Got The Time!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Please Enter a valid Answer");
                    }

                }
            }

        }
    }
}
