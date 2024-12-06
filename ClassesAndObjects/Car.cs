using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    internal class Car
    {
        //string type;
        //string company;
        //int year;

        public Car(string type, string company, int year)
        {
            this.Type = type;
            this.Company = company;
            this.Year = year;
        }

        public string Type { get; set;}
        public string Company { get; set; }
        public int Year { get; set; }


        public void horn() => Console.Beep();
        public void displayInfo() => Console.WriteLine($"Type: {Type}\nCompany: {Company}\nYear: {Year}");
    }
}
