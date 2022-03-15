using KipsuAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KipsuAssessment.UI
{
    public class UserInterface
    {
        public void WriteMessages(List<Guest> guests)
        {
            var messages = new List<String>();

            string line = "{0} {1}, and welcome to {2} in the beautiful {3}! Room {4} is now ready for you. Enjoy your stay, and please let us know if you need anything!";
            // {0} = Time of day greeting
            // {1} = First name of guest
            // {2} = Name of company
            // {3} = City
            // {4} = Room number

            foreach (Guest guest in guests)
            {
                string greeting;
                // midnight - 11:59a = "morning"
                DateTime midnight = new DateTime(1900, 1, 1, 0, 0, 0);
                DateTime noon = new DateTime(1900, 1, 1, 12, 0, 0);
                // noon - 3:59p = "afternoon"
                DateTime afternoon = new DateTime(1900, 1, 1, 16, 0, 0);
                // 4p - 11:59p = "evening"
                if (guest.Reservation.StartDate.TimeOfDay >= midnight.TimeOfDay && guest.Reservation.StartDate.TimeOfDay < noon.TimeOfDay)
                {
                    greeting = "Good morning";
                }
                else if (guest.Reservation.StartDate.TimeOfDay >= noon.TimeOfDay && guest.Reservation.StartDate.TimeOfDay < afternoon.TimeOfDay)
                {
                    greeting = "Good afternoon";
                }
                else
                {
                    greeting = "Good evening";
                }

                Console.WriteLine(line, greeting, guest.FirstName, guest.Reservation.Company.Name, guest.Reservation.Company.City, guest.Reservation.RoomNumber);
                Console.WriteLine();
            }
        }
    }
}
