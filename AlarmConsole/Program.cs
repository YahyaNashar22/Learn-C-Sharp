using System;
using System.Threading;

namespace AlarmConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Timer alarmClock = new Timer(Beep, null, 3000, Timeout.Infinite);
            Console.WriteLine("Alarm set for 3 seconds");

            Console.ReadKey();
        }

        private static void Beep(object? state)
        {
            int i = 0;

            while (i < 10)
            {
                Console.Beep();
                i++;
            }
            Console.WriteLine("WAKE UP YA WAYYYY!");
        }
    }
}
