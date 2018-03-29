using System;
using System.Collections.Generic;

namespace fun2travel.Models.Entities
{
    public partial class Hotel
    {
        public Hotel()
        {
            ActToHot = new HashSet<ActToHot>();
        }

        public int Id { get; set; }
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

        public ICollection<ActToHot> ActToHot { get; set; }
    }
}
