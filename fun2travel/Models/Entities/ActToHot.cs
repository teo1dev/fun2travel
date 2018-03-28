using System;
using System.Collections.Generic;

namespace fun2travel.Models.Entities
{
    public partial class ActToHot
    {
        public int Id { get; set; }
        public int? HotelFk { get; set; }
        public int ActivityFk { get; set; }

        public Activity ActivityFkNavigation { get; set; }
        public Hotel HotelFkNavigation { get; set; }
    }
}
