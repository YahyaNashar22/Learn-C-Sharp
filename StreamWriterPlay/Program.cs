namespace StreamWriterPlay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter streamWriter = new StreamWriter("output.txt");

            string input;

            Console.WriteLine("Enter desired text below:");
            Console.WriteLine("-------------------------");

            input = Console.ReadLine();

            streamWriter.WriteLine(input);

            streamWriter.Close();

            Console.ReadKey();
        }
    }
}
