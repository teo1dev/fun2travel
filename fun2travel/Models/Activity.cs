using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fun2travel.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string ActivityName { get; set; }
        public decimal ActivityPrice { get; set; }
        public decimal? ActivityRentalPrice { get; set; }
        public bool? EquipmentCanBeRented { get; set; }
        public string ActivityDescription { get; set; }

    }
}
