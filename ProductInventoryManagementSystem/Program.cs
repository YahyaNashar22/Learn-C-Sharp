namespace ProductInventoryManagementSystem
{
    enum Screens
    {
        Main,
        AddItem,
        ViewItems,
        DeleteItem,
    }


    internal class Program
    {
       static Screens screen = Screens.Main;

        static void Main(string[] args)
        {
        }

        static void MainMenu()
        {
            Console.WriteLine("Welcome To The Product Inventory Management System!");
            Console.WriteLine("How can we help you?");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("[1] - Add Item");
            Console.WriteLine("[2] - View Items");
            Console.WriteLine("[3] - Delete Item");

            int answer = int.Parse(Console.ReadLine());
            if (answer == 1)
            {
               screen = Screens.AddItem;
            }
        }
    }
}
