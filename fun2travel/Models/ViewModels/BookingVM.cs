using fun2travel.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fun2travel.Models.ViewModels
{
    public class BookingVM
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
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public string BookingEmail { get; set; }
        public string BookingPhone { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalCostHotel { get; set; }
        public decimal TotalCostActivity { get; set; }
        public decimal TotalCostRenting { get; set; }
        public decimal TotalCostTransport { get; set; }
        public int TotalNoNights { get; set; }
        public string ActivityName { get; set; }

        public string HotelLocation { get; set; }
        public string HotelAdress { get; set; }
        public int TotalNrOfBeds { get; set; }
        public decimal BedPricePerNight { get; set; }
        public string HotelDescription { get; set; }
        public decimal PriceForTransport { get; set; }
        public List<Activity> ActivityList { get; set; }
        public List<SelectListItem> SelectionActivityList { get; set; }
        [Required(ErrorMessage = "Please choose a date.")] //  => Bdb
        [CalendarValidatorStartEdit]
        public DateTime? SelectedDateFrom { get; set; } // Datetime set as null in bookingform for validation

        [Required(ErrorMessage = "Please choose a date.")] //  => Bdb
        [CalendarValidatorEndEdit]
        public DateTime? SelectedDateTo { get; set; }  // Datetime set as null in bookingform for validation

        
        public string ActivitySelected { get; set; }
        public string ActivitySelectedId { get; set; } //  => Bdb
        public bool RentEquipmentSelected { get; set; } //  => Bdb
        public bool EquipmentCanBeRented { get; set; }
        public bool TransportServiceSelected { get; set; } //  => Bdb
        public decimal TotalCostAll { get; set; } //  => Bdb
        public decimal TotalCostRentEq { get; set; } //  => Bdb
        /// Booking Customer Info

        [Required(ErrorMessage = "Please write your first name here.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; }  //  => Bdb
        [Required(ErrorMessage = "Please write your surename here.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Surename")]
        public string LastName { get; set; } //  => Bdb

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string EmailAddress { get; set; } //  => Bdb

        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; } //  => Bdb

        public DateTime BookingTimeStamp { get; set; }
    }
}
