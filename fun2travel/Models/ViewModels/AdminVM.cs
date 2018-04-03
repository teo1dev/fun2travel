using fun2travel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fun2travel.Models.ViewModels
{
    public class AdminVM
    {
        public string UserName { get; set; }

        //public int BookingId { get; set; }
        //public DateTime TimeStamp { get; set; }
        //public DateTime DateFrom { get; set; }
        //public DateTime DateTo { get; set; }
        //public string HotelName { get; set; }
        //public int NoPplForHotel { get; set; }
        //public int ActivityId { get; set; }
        //public int NoPplForActivity { get; set; }
        //public bool RentEquipment { get; set; }
        //public bool Transport { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string BookingEmail { get; set; }
        //public string BookingPhone { get; set; }
        //public double TotalCost { get; set; }
        //public int TotalNoNights { get; set; }

        public List<Booking> Bookings { get; set; }

    }
}
