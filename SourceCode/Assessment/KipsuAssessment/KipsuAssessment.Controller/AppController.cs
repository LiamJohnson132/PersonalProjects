using KipsuAssessment.Data;
using KipsuAssessment.Models;
using KipsuAssessment.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KipsuAssessment.Controller
{
    public class AppController
    {
        public void Run()
        {
            while (true)
            {
                Console.Clear();

                var userInterface = new UserInterface();

                userInterface.WriteMessages(ReadGuests());

                Console.ReadKey();
            }
        }

        public List<Guest> ReadGuests()
        {
            GuestsRepository guestRepo = new GuestsRepository();
            CompaniesRepository compRepo = new CompaniesRepository();

            var guests = guestRepo.GetGuests();

            foreach (var guest in guests)
            {
                guest.Reservation.Company = compRepo.GetCompanyById(guest.Reservation.Company.Id);

                // convert UST to Company time zone
                switch (guest.Reservation.Company.Timezone)
                {
                    case "US/Pacific":
                        guest.Reservation.StartDate.AddHours(-8);
                        guest.Reservation.EndDate.AddHours(-8);
                        break;
                    case "US/Mountain":
                        guest.Reservation.StartDate.AddHours(-7);
                        guest.Reservation.EndDate.AddHours(-7);
                        break;
                    case "US/Central":
                        guest.Reservation.StartDate.AddHours(-6);
                        guest.Reservation.EndDate.AddHours(-6);
                        break;
                    case "US/Eastern":
                        guest.Reservation.StartDate.AddHours(-5);
                        guest.Reservation.EndDate.AddHours(-5);
                        break;
                    default:
                        throw new Exception("Error: time zone not recognized");
                }
            }

            return guests;
        }
    }
}
