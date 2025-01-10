namespace ParseVSTryParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            int parsedInput;

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Hello, Wayyy!");
            Console.WriteLine("Welcome to Parse vs TryParse lesson!!!");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine();


            Console.Write("Enter you number:");
            input = Console.ReadLine();

            #region tryCatch
            try
            {
                parsedInput = int.Parse(input);
                Console.WriteLine("Parsed Correctly!");
            }
            catch
            {
                Console.WriteLine("Unable To Parse");
            }
            #endregion

            #region TryParse
            if (int.TryParse(input, out parsedInput))
            {
                Console.WriteLine("Parsed Correctly!");
            }
            else
            {
                Console.WriteLine("Unable To Parse");
            }
            #endregion
        }
    }
}
