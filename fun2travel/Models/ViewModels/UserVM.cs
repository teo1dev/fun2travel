﻿using fun2travel.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fun2travel.Models.ViewModels
{
    public class UserVM
    {
        public string UserName { get; set; }

        public List<Booking> Bookings { get; set; }

    }
}
