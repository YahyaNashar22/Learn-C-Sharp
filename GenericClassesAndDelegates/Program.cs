namespace GenericClassesAndDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("--Generic Classes And Delegates--");
            Console.WriteLine("---------------------------------");

            GenericClass<int> firstClass = new GenericClass<int>(23, 10);
            GenericClass<char> secondClass = new GenericClass<char>('C', 'D');

            firstClass.ShowType();
            secondClass.ShowType();

            firstClass.Field = 10;
            secondClass.Field = 'A';

            firstClass.ShowType();
            secondClass.ShowType();


            firstClass.Addition();
            secondClass.Addition();

            ShowValueAndType(1);

            void ShowValueAndType<TVariable>(TVariable myVariable)
            {
                Console.WriteLine($"The value of my variable is {myVariable} and the type is {myVariable.GetType()} ");
            }

        }
    }
}
