using System;

namespace Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console Calculator!");
            Console.WriteLine("First Number?");
            string firstNumber = Console.ReadLine();
            Console.WriteLine("Second Number?");
            string secondNumber = Console.ReadLine();
            int firstNumberInt = Convert.ToInt32(firstNumber);
            int secondNumberInt = Convert.ToInt32(secondNumber);
            Console.WriteLine($"Here are the result of different operations on {firstNumberInt} and {secondNumberInt}");
            Console.WriteLine($"{firstNumberInt} + {secondNumberInt} = {firstNumberInt+secondNumberInt}");
            Console.WriteLine($"{firstNumberInt} - {secondNumberInt} = {firstNumberInt - secondNumberInt}");
            Console.WriteLine($"{firstNumberInt} * {secondNumberInt} = {firstNumberInt * secondNumberInt}");
            Console.WriteLine($"{firstNumberInt} / {secondNumberInt} = {(double)firstNumberInt / secondNumberInt}");
            Console.WriteLine($"{firstNumberInt} | {secondNumberInt} = {firstNumberInt | secondNumberInt}");
            Console.WriteLine($"{firstNumberInt} & {secondNumberInt} = {firstNumberInt & secondNumberInt}");
            Console.WriteLine($"{firstNumberInt} ^ {secondNumberInt} = {firstNumberInt ^ secondNumberInt}");
            Console.WriteLine($"{firstNumberInt} << {secondNumberInt} = {firstNumberInt << secondNumberInt}");
            Console.WriteLine($"{firstNumberInt} >> {secondNumberInt} = {firstNumberInt >> secondNumberInt}");
        }
    }
}
