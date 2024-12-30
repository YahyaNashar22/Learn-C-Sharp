namespace PhraseItBackward
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] phrase = new string[4];

            for ( int i = 0; i < phrase.Length; i++ )
            {
                Console.WriteLine($"Enter the #{i + 1} word");
                phrase[i] = Console.ReadLine();
            }

            Console.WriteLine("---------------------------");

            for ( int i = phrase.Length - 1; i >= 0; i-- )
            {
                Console.WriteLine(phrase[i]);
            }
        }
    }
}
