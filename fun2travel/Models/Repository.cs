using fun2travel.Models.Entities;
using fun2travel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
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
                     Id = c.Id,
                     HotelPic1 = c.HotelPic1,
                     HotelPic2 = c.HotelPic2,
                     HotelPic3 = c.HotelPic3

                 }).ToArray();
            return q;
        }

        internal BookingVM GetHotelByIdToEditBookingVM(int id)
        {

            BookingVM booking = new BookingVM();

            var result = context.Booking.Find(id);

            booking.ActivityId = result.ActivityId;
            booking.ActivityName = result.ActivityName;
            booking.BookingEmail = result.BookingEmail;
            booking.BookingId = result.BookingId;
            booking.BookingPhone = result.BookingPhone;
            booking.DateFrom = result.DateFrom;
            booking.DateTo = result.DateTo;
            booking.FirstName = result.FirstName;
            booking.HotelName = result.HotelName;
            booking.Id = result.Id;
            booking.LastName = result.LastName;
            booking.NoPplForActivity = result.NoPplForActivity;
            booking.NoPplForHotel = result.NoPplForHotel;
            booking.RentEquipment = result.RentEquipment;
            booking.TimeStamp = result.TimeStamp;
            booking.TotalCost = result.TotalCost;
            booking.TotalCostActivity = result.TotalCostActivity;
            booking.TotalCostHotel = result.TotalCostHotel;
            booking.TotalCostRenting = result.TotalCostRenting;
            booking.TotalCostTransport = result.TotalCostTransport;
            booking.TotalNoNights = result.TotalNoNights;
            booking.Transport = result.Transport;

            Hotel hotel = new Hotel();

            hotel = context.Hotel.Where(h => h.HotelName == booking.HotelName)
                .Select(c => new Hotel
                {
                    Id = c.Id,
                    TotalNrOfBeds = c.TotalNrOfBeds,
                    HotelLocation = c.HotelLocation,
                    BedPricePerNight = Math.Round(c.BedPricePerNight, 0)

                }).FirstOrDefault();

            booking.TotalNrOfBeds = hotel.TotalNrOfBeds;
            booking.HotelLocation = hotel.HotelLocation;
            booking.BedPricePerNight = Math.Round(hotel.BedPricePerNight,0);

            var ActivityList = GetactivitiesbyHotelId(hotel.Id);
            var SelectionActivityList = GetActivitiesSelectListItem(hotel.Id);

            booking.ActivityList = ActivityList;
            booking.SelectionActivityList = SelectionActivityList;
            return booking;


        }

        internal void UpdateBooking(BookingVM bookingDetails)
        {
            throw new NotImplementedException();
        }

        public Activity GetAdventureById(int id)
        {
            return context.Activity
                .Find(id);

        }

        internal void SendConfirmationEmail(BookingDetailVM bookingDetails)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("funtotravel07@gmail.com");
            mail.To.Add(bookingDetails.EmailAddress);
            var dateFr = bookingDetails.SelectedDateFrom.Value.ToShortDateString();
            var dateTo = bookingDetails.SelectedDateTo.Value.ToShortDateString();
            mail.Subject = "Booking Confirmation";
            mail.Body = @"<html><h3>Confirmation Mail</h3>
                        <strong>Hotel name:</strong>      
                       <p>" + bookingDetails.HotelName + ", " + bookingDetails.HotelLocation +
                       "</p><strong>Hotel price:</strong><p>" + bookingDetails.BedPricePerNight +
                       " &euro;</p><strong>Number of nights:</strong><p> " + bookingDetails.TotalNoNights + "</p>" +
                       " <strong>Number of beds booked:</strong> " +
                       "<p> " + bookingDetails.NoPplForHotel + "</p>" +
                       "<strong>Hotel amount due:</ strong > " +
                       "<p> " + bookingDetails.TotalCostHotel + " &euro;</p>" +
                       "<h4> Booking ID </h4><h4>" + bookingDetails.BookingId + "</h4> " +
                          "<strong>Activity:</strong> " +
                       "<p> " + bookingDetails.ActivitySelected + "</p>" +
                       "<strong>No of persons booked:</strong> " +
                       "<p> " + bookingDetails.NoPplForActivity + "</p>" +
                       "<strong>Total Activity amount due:</strong> " +
                       "<p> " + bookingDetails.TotalCostActivity + " &euro;</p>" +
                       "<strong>Hotel and Activities booked from:</strong> " +
                       "<p> " + dateFr + "</p>" +
                       "<strong>Hotel and Activities booked from:</strong> " +
                       "<p> " + dateTo + "</p>" +
                       "<strong>Total Amount due:</strong> " +
                       "<p> " + bookingDetails.TotalCostAll + " &euro;</p>" +
                       "<br /><br /><br /><h3>Contact Details</h3> " +
                       "<p></p>" +
                       "<strong>Booking Time:</strong> " +
                       "<p> " + bookingDetails.BookingTimeStamp + "</p>" +
                       "<strong>First Name:</strong> " +
                       "<p> " + bookingDetails.FistName + "</p>" +
                       "<strong>Surename:</strong> " +
                       "<p> " + bookingDetails.LastName + "</p>" +
                       "<strong>Email address:</strong> " +
                       "<p> " + bookingDetails.EmailAddress + "</p>" +
                       "<strong>Phone number:</strong> " +
                       "<p> " + bookingDetails.PhoneNumber + "</p></html>";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential
            ("funtotravel07@gmail.com", "P@ssw0rd18"),
                EnableSsl = true
            };
            smtp.Send(mail);
        }

        internal List<Booking> getBookingByUserName(string userName)
        {
            var queryB = (from B in context.Booking
                          where B.BookingEmail == userName
                          select new
                          {
                              B.BookingId,
                              B.TimeStamp,
                              B.DateFrom,
                              B.DateTo,
                              B.HotelName,
                              B.NoPplForHotel,
                              B.ActivityId,
                              B.NoPplForActivity,
                              B.RentEquipment,
                              B.Transport,
                              B.FirstName,
                              B.LastName,
                              B.BookingEmail,
                              B.BookingPhone,
                              B.TotalCost,
                              B.TotalNoNights,
                              B.Id,
                              B.ActivityName
                          }).Distinct();
            var bookingslist = new List<Booking>();
            foreach (var item in queryB)
            {
                bookingslist.Add(new Booking
                {
                    BookingId = item.BookingId,
                    ActivityId = item.ActivityId,
                    BookingEmail = item.BookingEmail,
                    BookingPhone = item.BookingPhone,
                    DateFrom = item.DateFrom,
                    DateTo = item.DateTo,
                    FirstName = item.FirstName,
                    HotelName = item.HotelName,
                    LastName = item.LastName,
                    NoPplForActivity = item.NoPplForActivity,
                    NoPplForHotel = item.NoPplForHotel,
                    TimeStamp = item.TimeStamp,
                    RentEquipment = item.RentEquipment,
                    TotalCost = item.TotalCost,
                    Transport = item.Transport,
                    TotalNoNights = item.TotalNoNights,
                    Id = item.Id,
                    ActivityName = item.ActivityName

                });
            }
            return bookingslist;
        }

        internal void DeleteBooking(int id)
        {
            Booking bookingToDelete = new Booking();
            bookingToDelete = GetBookingById(id);
            context.Booking.Remove(bookingToDelete);
            context.SaveChanges();

        }

        private Booking GetBookingById(int id)
        {
            Booking booking = new Booking();

            return context.Booking.Find(id);
        }

        public AdventuresVM GetAdventureByIdToVM(int id)
        {
            Activity adventure = new Activity();
            var hotelList = GetHotelByActivityId(id);
            adventure = GetAdventureById(id);
            AdventuresVM adventureVm = new AdventuresVM
            {
                Id = adventure.Id,
                ActivityName = adventure.ActivityName,
                ActivityPrice = Math.Round(adventure.ActivityPrice, 0),
                ActivityRentalPrice = adventure.ActivityRentalPrice,
                ActivityDescription = adventure.ActivityDescription,
                ActivityPic1 = adventure.ActivityPic1,
                ActivityPic2 = adventure.ActivityPic2,
                HotelByActivity = hotelList

            };
            adventureVm.ActivityRentalPrice = Math.Round((decimal)adventureVm.ActivityRentalPrice, 0);
            return adventureVm;
        }

        internal void SavePrelBookingToDb(BookingDetailVM b)
        {
            var activityId = Convert.ToInt32(b.ActivitySelectedId);

            Booking booking = new Booking
            {
                ActivityId = activityId,
                BookingEmail = b.EmailAddress,
                BookingPhone = b.PhoneNumber,
                DateFrom = (DateTime)b.SelectedDateFrom,
                DateTo = (DateTime)b.SelectedDateTo,
                FirstName = b.FistName,
                HotelName = b.HotelName,
                BookingId = b.BookingId,
                LastName = b.LastName,
                NoPplForActivity = b.NoPplForActivity,
                NoPplForHotel = b.NoPplForHotel,
                TimeStamp = b.BookingTimeStamp,
                TotalCost = b.TotalCostAll,
                TotalCostActivity = b.TotalCostActivity,
                TotalCostHotel = b.TotalCostHotel,
                TotalCostRenting = b.TotalCostRentEq,
                TotalCostTransport = b.TotalCostTransport,
                TotalNoNights = b.TotalNoNights,
                Transport = b.TransportServiceSelected,
                RentEquipment = b.RentEquipmentSelected
            };
            context.Booking.Add(booking);
            context.SaveChanges();
        }

        internal BookingDetailVM GetbookingdetailsandCost(BookingDetailVM bookingDetails)
        {

            bookingDetails.BookingId = Get8Digits(); //BookingID

            bookingDetails.BookingTimeStamp = DateTime.Now; //Booking Timestamp

            bookingDetails.TotalNoNights = ((DateTime)bookingDetails.SelectedDateTo - (DateTime)bookingDetails.SelectedDateFrom).Days; // Calc total number of nights booked

            var activityId = Convert.ToInt32(bookingDetails.ActivitySelected);
            bookingDetails.ActivitySelectedId = bookingDetails.ActivitySelected;
            var querya = (from a in context.Activity
                          where a.Id == activityId

                          select new
                          {
                              activityName = a.ActivityName
                          });
            foreach (var item in querya)
            {
                bookingDetails.ActivitySelected = item.activityName;
            }

            var q = context.Activity
                .Where(a => a.Id == activityId)
                .Select(c => new BookingDetailVM
                {
                    PriceForRentEq = c.ActivityRentalPrice

                }).FirstOrDefault();
            bookingDetails.PriceForRentEq = q.PriceForRentEq;

            q = context.Activity
                .Where(a => a.Id == activityId)
                .Select(c => new BookingDetailVM
                {
                    PriceForActivity = c.ActivityPrice

                }).FirstOrDefault();
            bookingDetails.PriceForActivity = q.PriceForActivity;

            bookingDetails.TotalCostHotel = bookingDetails.NoPplForHotel * bookingDetails.BedPricePerNight;
            if (bookingDetails.RentEquipmentSelected)
            {
                bookingDetails.TotalCostRentEq = bookingDetails.NoPplForActivity * (decimal)bookingDetails.PriceForRentEq;
            }
            else
                bookingDetails.TotalCostRentEq = 0;
            if (bookingDetails.TransportServiceSelected)
            {
                bookingDetails.TotalCostTransport = bookingDetails.NoPplForHotel * bookingDetails.PriceForTransport;
            }
            else
                bookingDetails.TotalCostTransport = 0;

            bookingDetails.TotalCostActivity = bookingDetails.NoPplForActivity * (decimal)bookingDetails.PriceForActivity;
            bookingDetails.TotalCostAll =
                bookingDetails.TotalCostHotel
                + bookingDetails.TotalCostRentEq
                + bookingDetails.TotalCostTransport
                + bookingDetails.TotalCostActivity;
            bookingDetails.TotalCostAll = Math.Round(bookingDetails.TotalCostAll, 0);
            bookingDetails.TotalCostHotel = Math.Round(bookingDetails.TotalCostHotel, 0);
            bookingDetails.TotalCostRentEq = Math.Round(bookingDetails.TotalCostRentEq, 0);
            bookingDetails.TotalCostTransport = Math.Round(bookingDetails.TotalCostTransport, 0);
            bookingDetails.TotalCostActivity = Math.Round(bookingDetails.TotalCostActivity, 0);
            return bookingDetails;
        }

        private string Get8Digits() // Generate Booking Id
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D8}", random);
        }

        public AdventuresVM[] GetAllAdventures()
        {
            var a = context.Activity
                .Where(b => b.ActivityName != "")
                .Select(c => new AdventuresVM
                {
                    ActivityName = c.ActivityName,
                    Id = c.Id,
                    ActivityPic1 = c.ActivityPic1,
                    ActivityPic2 = c.ActivityPic2

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

        internal List<Booking> AllBookings()
        {

            var queryB = (from B in context.Booking
                          select new
                          {
                              B.BookingId,
                              B.TimeStamp,
                              B.DateFrom,
                              B.DateTo,
                              B.HotelName,
                              B.NoPplForHotel,
                              B.ActivityId,
                              B.NoPplForActivity,
                              B.RentEquipment,
                              B.Transport,
                              B.FirstName,
                              B.LastName,
                              B.BookingEmail,
                              B.BookingPhone,
                              B.TotalCost,
                              B.TotalNoNights,
                              B.Id,
                              B.ActivityName
                          }).Distinct();
            var bookingslist = new List<Booking>();
            foreach (var item in queryB)
            {
                bookingslist.Add(new Booking
                {
                    BookingId = item.BookingId,
                    ActivityId = item.ActivityId,
                    BookingEmail = item.BookingEmail,
                    BookingPhone = item.BookingPhone,
                    DateFrom = item.DateFrom,
                    DateTo = item.DateTo,
                    FirstName = item.FirstName,
                    HotelName = item.HotelName,
                    LastName = item.LastName,
                    NoPplForActivity = item.NoPplForActivity,
                    NoPplForHotel = item.NoPplForHotel,
                    TimeStamp = item.TimeStamp,
                    RentEquipment = item.RentEquipment,
                    TotalCost = item.TotalCost,
                    Transport = item.Transport,
                    TotalNoNights = item.TotalNoNights,
                    Id = item.Id,
                    ActivityName = item.ActivityName

                });
            }
            return bookingslist;
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
                        BedPricePerNight = Math.Round(item.BedPricePerNight, 0)

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
                        select new { h.HotelName, h.Id, h.BedPricePerNight };
                foreach (var item in q)
                {
                    resultList.Add(new ResultVM
                    {
                        HotelId = item.Id,
                        HotelName = item.HotelName,
                        BedPricePerNight = Math.Round(item.BedPricePerNight, 0)

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
                        select new { h.HotelName, h.Id, h.BedPricePerNight };
                foreach (var item in q)
                {
                    resultList.Add(new ResultVM
                    {
                        HotelId = item.Id,
                        HotelName = item.HotelName,
                        BedPricePerNight = Math.Round(item.BedPricePerNight, 0)

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

            HotelDetailVM hotelVm = new HotelDetailVM
            {
                Id = hotel.Id,
                HotelName = hotel.HotelName,
                HotelLocation = hotel.HotelLocation,
                HotelAdress = hotel.HotelAdress,
                BedPricePerNight = Math.Round(hotel.BedPricePerNight, 0),
                HotelDescription = hotel.HotelDescription,
                PriceForTransport = Math.Round(hotel.PriceForTransport, 0),
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
            var SelectionActivityList = GetActivitiesSelectListItem(id);
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
                HotelPic3 = hotel.HotelPic3,
                SelectionActivityList = SelectionActivityList

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
                    ActivityPrice = Math.Round(item.a.ActivityPrice, 0),
                    ActivityRentalPrice = item.a.ActivityRentalPrice,
                    EquipmentCanBeRented = item.a.EquipmentCanBeRented

                });
            }
            return list;

        }

        private List<SelectListItem> GetActivitiesSelectListItem(int id)
        {
            var query = (from h in context.Hotel
                         join m in context.ActToHot
                         on id equals m.HotelFk
                         join a in context.Activity
                         on m.ActivityFk equals a.Id
                         select new { a }).Distinct();

            var list = new List<SelectListItem>();
            foreach (var item in query)
            {
                list.Add(new SelectListItem
                {
                    Value = item.a.Id.ToString(),
                    Text = item.a.ActivityName
                });
            }
            return list;

        }

        private List<Hotel> GetHotelByActivityId(int id)
        {
            var query = (from h in context.Activity
                         join m in context.ActToHot
                         on id equals m.ActivityFk
                         join a in context.Hotel
                         on m.HotelFk equals a.Id
                         select new { a }).Distinct();

            var list = new List<Hotel>();
            foreach (var item in query)
            {
                list.Add(new Hotel
                {
                    HotelName = item.a.HotelName,
                    HotelLocation = item.a.HotelLocation

                });
            }
            return list;

        }


    }
}
