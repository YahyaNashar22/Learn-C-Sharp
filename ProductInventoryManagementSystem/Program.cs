using System.IO;

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
        static List<string> products = new List<string>();

        static void Main(string[] args)
        {
            LoadItems();

            while (true)
            {
                switch (screen)
                {
                    case Screens.Main: Console.Clear(); MainMenu(); break;
                    case Screens.AddItem: Console.Clear(); AddItemsScreen(); break;
                    case Screens.ViewItems: Console.Clear(); ViewItemsScreen(); break;
                    case Screens.DeleteItem: Console.Clear(); DeleteItemsScreen(); break;
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
                case (4): SaveAndExit(); break;
            }

        }

        static void AddItemsScreen()
        {
            string productName;
            string productPrice;

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
                    productPrice = Console.ReadLine();

                    products.Add($"{productName}: {productPrice}");
                }

            }
        }

        static void ViewItemsScreen()
        {
            Console.WriteLine("Available item in the inventory:");

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {products[i]}$");
            }

            Console.WriteLine("[1] - Go Back");
            int answer = int.Parse(Console.ReadLine());
            if (answer == 1)
            {
                screen = Screens.Main;
            }
        }

        static void DeleteItemsScreen()
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {products[i]}$");
            }

            Console.WriteLine();
            Console.WriteLine("Select Item Index To Delete:");
            while (true)
            {
                string answer = Console.ReadLine();
                if (answer == "")
                {
                    screen = Screens.Main;
                    break;
                }
                else
                {
                    Console.WriteLine($"Deleted {products[int.Parse(answer)]}");

                    products.RemoveAt(int.Parse(answer));
                }
            }
        }

        static void SaveAndExit()
        {
            StreamWriter streamWriter = new StreamWriter("inventory.txt");
            for (int i = 0; i < products.Count; i++)
            {
                streamWriter.WriteLine($"{i + 1} - {products[i]}");
            }
            streamWriter.Close();

            Environment.Exit(0);
        }

        static void LoadItems()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader("inventory.txt"))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string input = streamReader.ReadLine();
                        string[] parts = input.Split(new[] { "- " }, StringSplitOptions.None);
                        if (parts.Length > 1)
                        {
                            products.Add(parts[1].Trim());
                        }

                    }
                    streamReader.Close();

                }
            }
            catch
            {
                Console.WriteLine("No previous inventory found!");
            }

        }
    }
}
