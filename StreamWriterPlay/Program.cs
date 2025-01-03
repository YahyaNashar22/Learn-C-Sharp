namespace StreamWriterPlay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter streamWriter = new StreamWriter("output.txt");

            string input;
            string fromFile;
            string answer;
            
            Console.WriteLine("Enter desired text below:");
            Console.WriteLine("-------------------------");
            Console.WriteLine();

            input = Console.ReadLine();

            streamWriter.WriteLine(input);

            streamWriter.Close();

            Console.WriteLine("Do you want to add something else?");

            answer = Console.ReadLine();

            if (answer == "y")
            {
                streamWriter = new StreamWriter("output.txt", true);
                Console.WriteLine("Enter desired text below:");
                Console.WriteLine("-------------------------");
                Console.WriteLine();

                input = Console.ReadLine();

                streamWriter.WriteLine(input);

                streamWriter.Close();
            }


            StreamReader streamReader = new StreamReader("output.txt");

            fromFile = streamReader.ReadToEnd();

            Console.WriteLine("You Entered:");
            Console.WriteLine("------------");
            Console.WriteLine();
            Console.WriteLine(fromFile);

            streamReader.Close();

            Console.ReadKey();
        }
    }
}
