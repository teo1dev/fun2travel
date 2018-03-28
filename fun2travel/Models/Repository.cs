using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fun2travel.Models
{
    public class Repository
    {

        public List<Hotel> hotelList = new List<Hotel>
        {
            new Hotel{Id=1,Name="Hotel1",Location="Bern",Description="Description for hotel 1",HotelActivityList=new List<Activity>() },
            new Hotel{Id=2,Name="Hotel2",Location="Paris",Description="Description for hotel 2",HotelActivityList=new List<Activity>() },
            new Hotel{Id=3,Name="Hotel3",Location="Stockholm",Description="Description for hotel 3",HotelActivityList=new List<Activity>() },
            new Hotel{Id=4,Name="Hotel4",Location="Gdansk",Description="Description for hotel 4",HotelActivityList=new List<Activity>() }
        };
        
        internal Hotel GetHotelById(int id)
        {
            return hotelList.Find(i => i.Id == id);
        }
    }
}
