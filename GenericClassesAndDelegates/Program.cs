namespace GenericClassesAndDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("--Generic Classes And Delegates--");
            Console.WriteLine("---------------------------------");

            #region Generic Classes

            //GenericClass<int> firstClass = new GenericClass<int>(23, 10);
            //GenericClass<char> secondClass = new GenericClass<char>('C', 'D');

            //firstClass.ShowType();
            //secondClass.ShowType();

            //firstClass.Field = 10;
            //secondClass.Field = 'A';

            //firstClass.ShowType();
            //secondClass.ShowType();


            //firstClass.Addition();
            //secondClass.Addition();

            //ShowValueAndType(1);

            //void ShowValueAndType<TVariable>(TVariable myVariable)
            //{
            //    Console.WriteLine($"The value of my variable is {myVariable} and the type is {myVariable.GetType()} ");
            //}

            #endregion


            #region Callback methods
            //void ShowResult(int result) => Console.WriteLine($"The Result is --> {result}");


            //Calculate calculateMult = new Calculate(Multiply);

            //void Sum(int x, int y, Action<int> showResult)
            //{
            //    int result = x + y;
            //    showResult(result);
            //}

            //void Substract(int x, int y, Action<int> substract)
            //{
            //    int result = x - y;
            //    substract(result);
            //}

            //void Multiply(int x, int y)
            //{
            //    Console.WriteLine($"{x} * {y} = {x * y}");
            //}


            //Sum(1, 3, ShowResult);

            //// Anonymous callback
            //Substract(10, 3, (result) =>
            //    {
            //        Console.WriteLine($"The Substraction result is --> {result}");
            //    });

            //calculateMult(4, 10);

            #endregion

            Circle circle = new Circle();
            Circle.CircleDelegate circleDelegate = new Circle.CircleDelegate(circle.Area);
            circleDelegate += circle.Perimeter;

            circleDelegate(20);
        }
    }
    public delegate void Calculate(int x, int y);

}
