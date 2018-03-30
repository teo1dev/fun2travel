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
        public IActionResult Booking(BookingDetailVM model)
        {
            if (!ModelState.IsValid)
            {
                model = repository.GetHotelByIdToBookingVM(model.Id);
                return View(model);
            }

            // save booking
            return RedirectToAction(nameof(BookingConfirmation));

        }
        [HttpGet]
        public IActionResult BookingConfirmation()
        {

            return View();
        }
    }
}
