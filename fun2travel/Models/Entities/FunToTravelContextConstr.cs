using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace fun2travel.Models.Entities
{
    public partial class FunToTravelContext : DbContext
    {
      public FunToTravelContext(DbContextOptions<FunToTravelContext> options) : base(options)
        {

        }
    }
    
}
