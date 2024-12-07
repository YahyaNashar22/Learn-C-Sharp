using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    internal class Vehicle
    {
        public Vehicle(bool available)
        {
            this.Available = available;
        }

        protected bool Available { get; set; }

        public void Horn() => Console.Beep(); 

        public void IsAvailable() => Console.WriteLine(Available);

        public virtual string ShowMe() => "What do you want to see?";
    }

    public interface IFourWheels
    {
        void Drive();

    }
}
