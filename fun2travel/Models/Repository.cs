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
        public Activity GetAdventureById(int id) 
        {
            return context.Activity
                .Find(id);

        }


        public AdventuresVM GetAdventureByIdToVM(int id)
        {
            Activity adventure = new Activity();
          
            adventure = GetAdventureById(id);
            AdventuresVM adventureVm = new AdventuresVM
            {
                Id = adventure.Id,
                ActivityName=adventure.ActivityName,
                ActivityPrice=Math.Round(adventure.ActivityPrice,0),
                ActivityRentalPrice=adventure.ActivityRentalPrice,
                ActivityDescription=adventure.ActivityDescription,
                ActivityPic1=adventure.ActivityPic1,
                ActivityPic2=adventure.ActivityPic2

            };
            return adventureVm;
        }


        public AdventuresVM[] GetAllAdventures()
        {
            var a = context.Activity
                .Where(b => b.ActivityName != "")
                .Select(c => new AdventuresVM
                {
                    ActivityName = c.ActivityName,
                    Id = c.Id,
                    ActivityPic1=c.ActivityPic1,
                    ActivityPic2=c.ActivityPic2

                }).ToArray();
            return a;
        }

        internal List<IndexVM> AllHotelandActivitytoVM()
        {
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

        internal List<ResultVM> FilterHotelandActivityPartialView(string locationName, string activityName)
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
                         HotelName = c.HotelName,
                         BedPricePerNight = c.BedPricePerNight
                     }).ToList();
                foreach (var item in q)
                {
                    resultList.Add(new ResultVM
                    {
                        HotelId = item.HotelId,
                        HotelName = item.HotelName,
                        BedPricePerNight = Math.Round(item.BedPricePerNight,0)

                    });
                }
            }

            // if only activity are selected:
            if (activityName != null && locationName == null)
            {
                var q = from a in context.Activity
                            join m in context.ActToHot
                            on a.Id equals m.ActivityFk
                            join h in context.Hotel
                            on m.HotelFk equals h.Id
                            where a.ActivityName == activityName
                            select new { h.HotelName, h.Id, h.BedPricePerNight};
                foreach (var item in q)
                {
                    resultList.Add(new ResultVM
                    {
                        HotelId = item.Id,
                        HotelName = item.HotelName,
                        BedPricePerNight = Math.Round(item.BedPricePerNight,0)

                    });

                }
            }
            // if both location and activity are selected
            if (activityName != null && locationName != null)
            {
                var q = from a in context.Activity
                        join m in context.ActToHot
                        on a.Id equals m.ActivityFk
                        join h in context.Hotel
                        on m.HotelFk equals h.Id
                        where a.ActivityName == activityName && h.HotelLocation == locationName
                        select new { h.HotelName, h.Id, h.BedPricePerNight};
                foreach (var item in q)
                {
                    resultList.Add(new ResultVM
                    {
                        HotelId = item.Id,
                        HotelName = item.HotelName,
                        BedPricePerNight = Math.Round(item.BedPricePerNight,0)

                    });

                }
            }
            return resultList;
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
            //var ActivityOptionsList = GetActivitiesSelectListItem(id);
            HotelDetailVM hotelVm = new HotelDetailVM
            {
                Id = hotel.Id,
                HotelName = hotel.HotelName,
                HotelLocation = hotel.HotelLocation,
                HotelAdress=hotel.HotelAdress,
                BedPricePerNight = Math.Round(hotel.BedPricePerNight,0),
                HotelDescription = hotel.HotelDescription,
                PriceForTransport = Math.Round(hotel.PriceForTransport,0),
                TotalNrOfBeds = hotel.TotalNrOfBeds,
                ActivityList = ActivityList,
                HotelPic1 = hotel.HotelPic1,
                HotelPic2 = hotel.HotelPic2,
                HotelPic3 = hotel.HotelPic3

            };
            return hotelVm;
        }

        public BookingDetailVM GetHotelByIdToBookingVM(int id)
        {
            Hotel hotel = new Hotel();
            hotel = GetHotelById(id);
            var ActivityList = GetactivitiesbyHotelId(id);
            //var ActivityOptionsList = GetActivitiesSelectListItem(id);
            BookingDetailVM bookingVm = new BookingDetailVM
            {
                Id = hotel.Id,
                HotelName = hotel.HotelName,
                HotelLocation = hotel.HotelLocation,
                BedPricePerNight = Math.Round(hotel.BedPricePerNight, 0),
                HotelDescription = hotel.HotelDescription,
                PriceForTransport = Math.Round(hotel.PriceForTransport, 0),
                TotalNrOfBeds = hotel.TotalNrOfBeds,
                ActivityList = ActivityList,
                HotelPic1 = hotel.HotelPic1,
                HotelPic2 = hotel.HotelPic2,
                HotelPic3 = hotel.HotelPic3

            };
            return bookingVm;
        }
        
        private List<Activity> GetactivitiesbyHotelId(int id)
        {
            var query = (from h in context.Hotel
                        join m in context.ActToHot
                        on id equals m.HotelFk
                        join a in context.Activity
                        on m.ActivityFk equals a.Id
                        select new { a }).Distinct();

            var list = new List<Activity>();
            foreach (var item in query)
            {
                list.Add(new Activity
                {
                    ActivityName = item.a.ActivityName,
                    ActivityDescription = item.a.ActivityDescription,
                    ActivityPrice = Math.Round(item.a.ActivityPrice,0),
                    ActivityRentalPrice = item.a.ActivityRentalPrice,
                    EquipmentCanBeRented = item.a.EquipmentCanBeRented

                });
            }
            return list;

        }
    }
}
