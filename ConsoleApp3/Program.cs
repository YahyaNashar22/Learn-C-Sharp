namespace StringsArraysAndLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Arrays contain same data type and have fixed Size
            int[,] numbers = { { 1, 3, 3 }, { 1, 2, 3 }, { 5, 1, 3 } };
            Console.WriteLine($"Number of rows: {numbers.GetLength(0)}");
            Console.WriteLine($"Number of columns: {numbers.GetLength(1)}");

            numbers[1, 1] = 4;
            Console.WriteLine(numbers[1, 1]);

            Console.WriteLine("----------------");


            // Lists contain different data types and can be resized
            List<dynamic> colors = [ "red", "blue", "yellow" ];
            colors.Add("green");
            colors.Add(4);

            Console.WriteLine($"Colors length is: {colors.Count}");

            foreach ( var color in colors )
            {
                Console.WriteLine(color);
            }
        }
    }
}
