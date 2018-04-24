using fun2travel.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fun2travel.Models.ViewModels
{
    public class AddHotelVM
    {
        public string HotelName { get; set; }
        public string HotelLocation { get; set; }
        public int TotalNrOfBeds { get; set; }
        public decimal BedPricePerNight { get; set; }
        public string HotelDescription { get; set; }
        public decimal PriceForTransport { get; set; }
        public string HotelAdress { get; set; }
        public string HotelPic1 { get; set; }
        public string HotelPic2 { get; set; }
        public string HotelPic3 { get; set; }

        //public string ActivityName { get; set; }
        public List<Activity> Activities { get; set; }

        //public MultiSelectList Acts { get; set; } //kolla länken https://www.codeproject.com/Articles/1063846/Step-By-Step-Implementation-of-MultiSelectList-In step 3



    }
}
