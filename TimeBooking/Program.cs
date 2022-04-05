using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeBooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours;

            int minutes;

            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sFile = System.IO.Path.Combine(sCurrentDirectory, @"..\..\Assets\TimeBookings.txt");
            string sFilePath = Path.GetFullPath(sFile);

            string[] timeBookings = File.ReadAllLines(sFilePath);

            //DateTime comeTime = DateTime.ParseExact("05-04-2022 07:45:00", "dd-MM-yyyy HH:mm:ss", null);
            //DateTime actualComeTime = DateTime.ParseExact("05-04-2022 12:20:00", "dd-MM-yyyy HH:mm:ss", null);

            //TimeSpan timeToAdd = actualComeTime - comeTime;

            int counter = 0;
            DateTime comeTime = DateTime.Now;
            DateTime actualComeTime = DateTime.Now;
            TimeSpan timeToAdd;

            Console.WriteLine("Current Time in format HH:mm");
            string userInput = Console.ReadLine();
            Console.WriteLine();

            string [] time =  userInput.Split(':');

            int totalH = Int32.Parse(time[0]);
            int totalM = Int32.Parse(time[1]);

            TimeSpan totalTime = new TimeSpan(totalH, totalM, 0);


            foreach (string booking in timeBookings)
            {
                timeToAdd = new TimeSpan();

                if (booking.Equals("NEW DAY"))
                {
                    continue;
                }

                if (counter == 0)
                {
                    comeTime = DateTime.ParseExact(booking, "dd-MM-yyyy HH:mm:ss", null);
                }

                if (counter == 1)
                {
                    actualComeTime = DateTime.ParseExact(booking, "dd-MM-yyyy HH:mm:ss", null);
                    timeToAdd = actualComeTime - comeTime;
                    totalTime += timeToAdd;

                    counter = 0;
                    continue;
                }

                counter++;
            }

            Console.WriteLine(totalTime);

            Console.ReadLine();

        }
    }
}
