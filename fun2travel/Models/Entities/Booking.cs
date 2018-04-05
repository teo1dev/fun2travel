using System;
using System.Collections.Generic;

namespace fun2travel.Models.Entities
{
    public partial class Booking
    {
        public int Id { get; set; }
        public string BookingId { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string HotelName { get; set; }
        public int NoPplForHotel { get; set; }
        public int ActivityId { get; set; }
        public int NoPplForActivity { get; set; }
        public bool RentEquipment { get; set; }
        public bool Transport { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BookingEmail { get; set; }
        public string BookingPhone { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalCostHotel { get; set; }
        public decimal TotalCostActivity { get; set; }
        public decimal TotalCostRenting { get; set; }
        public decimal TotalCostTransport { get; set; }
        public int TotalNoNights { get; set; }
        public string ActivityName { get; set; }
        public bool? IsEdited { get; set; }
    }
}
