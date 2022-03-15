using KipsuAssessment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KipsuAssessment.Data
{
    public class GuestsRepository
    {
        public List<Guest> GetGuests()
        {
            string path = "Files/Guests.json";

            var file = new StreamReader(path);

            var guests = JsonSerializer.Deserialize<List<Guest>>(file.ReadToEnd());

            foreach (var guest in guests)
            {
                // converts timestamps into UST datetime
                DateTime startDate = DateTime.Parse("1/1/1970").AddSeconds(guest.Reservation.StartTimeStamp);
                DateTime endDate = DateTime.Parse("1/1/1970").AddSeconds(guest.Reservation.EndTimeStamp);

                guest.Reservation.StartDate = startDate;
                guest.Reservation.EndDate = endDate;
            }

            return guests;
        }
    }
}
