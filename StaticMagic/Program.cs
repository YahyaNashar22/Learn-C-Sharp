namespace StaticMagic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("product1", 13);
            Product product2 = new Product("product2", 20);


            Console.ReadKey();

        }
    }

    class Product
    {
        private int _count1;
        private static int _count2;


        public String Name { get; set; }
        public int Price {  get; set; }

        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;

            _count1++;
            Console.WriteLine($"Count 1: {_count1}");

            _count2++;
            Console.WriteLine($"Count 2: {_count2}");
        }


    }

}
