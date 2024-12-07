using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    internal class Car : Vehicle
    {
        #region fields
        //string type;
        //string company;
        //int year;
        #endregion

        public Car(string type, string company, int year, bool available) : base (available)
        {
            this.Type = type;
            this.Company = company;
            this.Year = year;
            this.Available = available;
        }

        public string Type { get; set;}
        public string Company { get; set; }
        public int Year { get; set; }


        public void DisplayInfo() => Console.WriteLine($"Type: {Type}\nCompany: {Company}\nYear: {Year}");

        public void ChangeAvailability() => Available = !Available;
    }
}
