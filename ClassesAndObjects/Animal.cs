using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    internal abstract class Animal
    {
        public static void MakeSound() => Console.WriteLine("The animal is making a sound.");

        public abstract void Eat();
    }

    internal class Cat : Animal
    {
        public override void Eat() => Console.WriteLine("Cat is eating tuna");

    }

    internal sealed class Turtle : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Turtle is eating...");
        }
    }
}
