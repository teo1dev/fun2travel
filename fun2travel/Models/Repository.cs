﻿using fun2travel.Models.Entities;
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

        public HotelsVM[] GetAllHotelNames() // för att lägga in hotellnamnen i korten automagiskt
        {
            var q = context.Hotel
                 .Where(e => e.HotelName != "")
                 .Select(c => new HotelsVM
                 {
                     HotelName = c.HotelName,
                     Id=c.Id,
                     HotelPic1=c.HotelPic1,
                     HotelPic2=c.HotelPic2,
                     HotelPic3=c.HotelPic3

                 }).ToArray();
            return q;
        }

        internal List<IndexVM> AllHotelandActivitytoVM()
        {
            var query = from h in context.Hotel
                        join m in context.ActToHot
                        on h.Id equals m.HotelFk
                        join a in context.Activity
                        on "Mounatinbiking" equals a.ActivityName
                        select new { h.HotelName };

            var queryh = (from h in context.Hotel
                          select new
                          {
                              HotelLocation = h.HotelLocation
                          }).Distinct();

            var querya = (from a in context.Activity
                          select new
                          {
                              ActivityName = a.ActivityName
                          }).Distinct();

            var list = new List<IndexVM>();
            foreach (var item in queryh)
            {
                list.Add(new IndexVM
                {
                    HotelLocation = item.HotelLocation

                });
            }
            foreach (var act in querya)
            {
                list.Add(new IndexVM
                {
                    ActivityName = act.ActivityName

                });
            }
            return list;

        }

        internal ResultVM FilterHotelandActivityPartialView(string locationName, string activityName)
        {
            List<ResultVM> resultList = new List<ResultVM>();

            // if only location are selected:
            if (activityName == null && locationName != null)
            {
                var q = context.Hotel
                     .Where(h => h.HotelLocation == locationName)
                     .Select(c => new ResultVM
                     {
                         HotelId = c.Id,
                         HotelName = c.HotelName
                     }).ToList();
                foreach (var item in q)
                {
                    resultList.Add(new ResultVM
                    {
                        HotelId = item.HotelId,
                        HotelName = item.HotelName
                    });

                }
            }

            // if only activity are selected:
            if (activityName != null && locationName == null)
            {
                var query = from m in context.ActToHot
                            join a in context.Activity
                            on locationName equals a.ActivityName
                            join h in context.Hotel
                            on m.ActivityFk equals h.Id
                            select new { h };
            }
            return null;
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
                ActivityList = ActivityList,
                HotelPic1 = hotel.HotelPic1,
                HotelPic2 = hotel.HotelPic2,
                HotelPic3 = hotel.HotelPic3

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
