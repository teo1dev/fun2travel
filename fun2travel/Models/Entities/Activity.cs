using System;
using System.Collections.Generic;

namespace fun2travel.Models.Entities
{
    public partial class Activity
    {
        public Activity()
        {
            ActToHot = new HashSet<ActToHot>();
        }

        public int Id { get; set; }
        public string ActivityName { get; set; }
        public decimal ActivityPrice { get; set; }
        public decimal? ActivityRentalPrice { get; set; }
        public bool? EquipmentCanBeRented { get; set; }
        public string ActivityDescription { get; set; }

        public ICollection<ActToHot> ActToHot { get; set; }
    }
}
