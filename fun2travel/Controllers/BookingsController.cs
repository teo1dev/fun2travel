using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fun2travel.Models;
using fun2travel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fun2travel.Controllers
{
    public class BookingsController : Controller
    {
        private readonly Repository repository;

        public BookingsController(Repository repository)
        {
            this.repository = repository;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Booking(int id)
        {

            return View(repository.GetHotelByIdToBookingVM(id));
        }
        [HttpPost]
        public IActionResult Booking(BookingDetailVM bookingDetails)
        {
            if (!ModelState.IsValid)
            {
                bookingDetails = repository.GetHotelByIdToBookingVM(bookingDetails.Id);
                return View(bookingDetails);
            }

            // write prel booking to DB, generate booking ID and send to BookingConfirmation action?
            repository.SavePrelBookingToDb(bookingDetails);
            bookingDetails = repository.GetbookingdetailsandCost(bookingDetails);
            return View("BookingConfirmation", bookingDetails);

        }
        [HttpGet]
        public IActionResult BookingConfirmation(BookingDetailVM bookingDetails)
        {
            
            return View(bookingDetails);
        }
        [HttpPost]
        public IActionResult BookingConfirmation()
        {
            /// Send email to confirm booking and write things to DB
            return View();
        }
    }
}
