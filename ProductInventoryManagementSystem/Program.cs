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
        static List<string> productNames = new List<string>();
        static List<double> productPrices = new List<double>();


        static void Main(string[] args)
        {
            while (true)
            {
                switch (screen)
                {
                    case Screens.Main:  Console.Clear();  MainMenu(); break;
                    case Screens.AddItem: Console.Clear();  AddItemsScreen(); break;
                    case Screens.ViewItems: Console.Clear();  ViewItemsScreen(); break;
                }
            }
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
            Console.WriteLine("[4] - Save & Quit");


            int answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case (1): screen = Screens.AddItem; break;
                case (2): screen = Screens.ViewItems; break;
                case (3): screen = Screens.DeleteItem; break;
                case (4): Environment.Exit(0); break;
            }

        }

        static void AddItemsScreen()
        {
            string productName;
            double productPrice;

            while (true)
            {
                Console.Write("Enter the product's name:");
                productName = Console.ReadLine();
                if (productName == "")
                {
                    screen = Screens.Main;
                    break;
                }
                else
                {
                    Console.Write("Enter the product's price:");
                    productPrice = double.Parse(Console.ReadLine());

                    productNames.Add(productName);
                    productPrices.Add(productPrice);
                }

            }
        }

        static void ViewItemsScreen()
        {
            Console.WriteLine("Available item in the inventory:");

            for (int i = 0; i < productNames.Count; i++)
            {
                Console.WriteLine($"{productNames[i]} - {productPrices[i]}$");
            }

            Console.WriteLine("[1] - Go Back");
            int answer = int.Parse(Console.ReadLine());
            if (answer == 1)
            {
                screen = Screens.Main;
            }
        }
    }
}
