using fun2travel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fun2travel.Models.ViewModels
{
    public class ManageActVM
    {
        public List<Hotel> Hotels { get; set; }
        public List<Activity> Activities { get; set; }
        public int HotelFk { get; set; }
        public int ActivityFk { get; set; }


    }
}
