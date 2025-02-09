namespace HashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("--------- Welcome To HashSets ---------");
            Console.WriteLine("---------------------------------------");


            HashSet<int> set = new();

            set.Add(1);
            set.Add(2);
            set.Add(1);

            Console.WriteLine($"set.Add(1) evaluates to false because the HashSet already contains the value 1: {set.Add(1)}");

            foreach (int item in set)
            {
                Console.WriteLine(item);
            }

        }
    }
}
