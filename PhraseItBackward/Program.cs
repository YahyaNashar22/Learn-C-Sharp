namespace PhraseItBackward
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region phrase
            //string[] phrase = new string[4];

            //for ( int i = 0; i < phrase.Length; i++ )
            //{
            //    Console.WriteLine($"Enter the #{i + 1} word");
            //    phrase[i] = Console.ReadLine();
            //}

            //Console.WriteLine("---------------------------");

            //for ( int i = phrase.Length - 1; i >= 0; i-- )
            //{
            //    Console.WriteLine(phrase[i]);
            //}

            #endregion


            #region addNumbers

            int[] numbers = new int[4];
            bool success;
            int sum = 0;

            Console.WriteLine("Enter the numbers you want to add");
            Console.WriteLine("---------------------------------");

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Enter the #{i + 1} number:");
                success = int.TryParse(Console.ReadLine(), out numbers[i]);
                if (!success)
                {
                    Console.WriteLine("Invalid integer");
                }
            }


            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine("The Total Sum of all Numbers is: " + sum);


            #endregion
        }
    }
}
