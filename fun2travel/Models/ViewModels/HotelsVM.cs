﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fun2travel.Models.ViewModels
{
    public class HotelsVM
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public string HotelPic1 { get; set; }
        public string HotelPic2 { get; set; }
        public string HotelPic3 { get; set; }

        public string HotelLocation { get; set; }
        public string HotelAdress { get; set; }
        public int TotalNrOfBeds { get; set; }
        public decimal BedPricePerNight { get; set; }
        public string HotelDescription { get; set; }
        public decimal PriceForTransport { get; set; }

    }
}
