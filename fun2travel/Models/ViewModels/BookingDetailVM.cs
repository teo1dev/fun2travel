﻿using fun2travel.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fun2travel.Models.ViewModels
{
    public class BookingDetailVM
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public string HotelLocation { get; set; }
        public int TotalNrOfBeds { get; set; }
        public decimal BedPricePerNight { get; set; }
        public string HotelDescription { get; set; }
        public decimal PriceForTransport { get; set; }
        public decimal? PriceForRentEq { get; set; }
        public decimal? PriceForActivity { get; set; }
        public string HotelPic1 { get; set; }
        public string HotelPic2 { get; set; }
        public string HotelPic3 { get; set; }
        public List<Activity> ActivityList { get; set; }
        public List<SelectListItem> SelectionActivityList { get; set; }

        /// Variables from Form

        [Required(ErrorMessage = "Please choose a date.")]
        public DateTime? SelectedDateFrom { get; set; } // Datetime set as null in bookingform for validation

        [Required(ErrorMessage = "Please choose a date.")]
        public DateTime? SelectedDateTo { get; set; }  // Datetime set as null in bookingform for validation

        public int NoPplForHotel { get; set; }

        public string ActivitySelected { get; set; }
        public int NoPplForActivity { get; set; }
        public bool RentEquipmentSelected { get; set; }

        public bool TransportServiceSelected { get; set; }
        public decimal TotalCostAll { get; set; }
        public decimal TotalCostHotel { get; set; }
        public decimal TotalCostActivity { get; set; }
        public decimal TotalCostRentEq { get; set; }
        public decimal TotalCostTransport { get; set; }
        /// Booking Customer Info

        [Required]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Your must provide a PhoneNumber")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string PhoneNumber { get; set; }


    }
}