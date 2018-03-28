using fun2travel.Models.Entities;
using fun2travel.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fun2travel.Models
{
    public class Repository
    {

        private readonly FunToTravelContext context;

        public Repository(FunToTravelContext context)
        {
            this.context = context;
        }

        public Hotel GetHotelById(int id)
        {
            return context.Hotel
                .Find(id);
        }

        public HotelDetailVM GetHotelByIdToVM(int id)
        {
            Hotel hotel = new Hotel();
            hotel = GetHotelById(id);
            var ActivityList = GetactivitiesbyHotelId(id);

            HotelDetailVM hotelVm = new HotelDetailVM
            {
                Id = hotel.Id,
                HotelName = hotel.HotelName,
                HotelLocation = hotel.HotelLocation,
                BedPricePerNight = hotel.BedPricePerNight,
                HotelDescription = hotel.HotelDescription,
                PriceForTransport = hotel.PriceForTransport,
                TotalNrOfBeds = hotel.TotalNrOfBeds,
                ActivityList = ActivityList

            };
            return hotelVm;
        }

        /// Fix return type or something

        private List<Activity> GetactivitiesbyHotelId(int id)
        {
            var query = from h in context.Hotel
                        join m in context.ActToHot
                        on id equals m.HotelFk
                        join a in context.Activity
                        on m.ActivityFk equals a.Id
                        select new { a };

            var list = new List<Activity>();
            foreach (var item in query)
            {
                list.Add(new Activity
                {
                    ActivityName = item.a.ActivityName,
                    ActivityDescription = item.a.ActivityDescription,
                    ActivityPrice = item.a.ActivityPrice,
                    ActivityRentalPrice = item.a.ActivityRentalPrice,
                    EquipmentCanBeRented = item.a.EquipmentCanBeRented

                });
            }
            return list;

        }
    }
}
