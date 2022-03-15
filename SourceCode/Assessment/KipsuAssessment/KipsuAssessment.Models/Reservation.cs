using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KipsuAssessment.Models
{
    public class Reservation
    {
        public int RoomNumber { get; set; }
        public int StartTimeStamp { get; set; }
        public int EndTimeStamp { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Company Company { get; set; }
    }
}
