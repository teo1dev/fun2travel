﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fun2travel.Models;
using fun2travel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using fun2travel.Models.Entities;

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
            bookingDetails = repository.GetbookingdetailsandCost(bookingDetails);
            repository.SavePrelBookingToDb(bookingDetails);
            repository.SendConfirmationEmail(bookingDetails);
            return View("BookingConfirmation", bookingDetails);

        }
        [HttpGet]
        public IActionResult BookingConfirmation(BookingDetailVM bookingDetails)
        {

            //return View(bookingDetails);            
            return View("BookingConfirmationSendEmail", bookingDetails);
        }
        [HttpGet]
        public IActionResult BookingConfirmationSendEmail()
        {

            return View();           
            
        }

        [HttpPost]
        public IActionResult DeleteBooking(int Id)
        {
            repository.DeleteBooking(Id);
            return Ok();
        }
        [HttpGet]
        public IActionResult EditBooking(int id)
        {
            BookingVM booking = new BookingVM();
            booking = repository.GetHotelByIdToEditBookingVM(id);
            return View(booking);
        }
        [HttpPost]
        public IActionResult EditBooking(BookingVM bookingDetails)
        {
            if (!ModelState.IsValid)
            {
                bookingDetails = repository.GetHotelByIdToEditBookingVM(bookingDetails.Id);
                return View(bookingDetails);
            }

            // write prel booking to DB, generate booking ID and send to BookingConfirmation action?
            repository.UpdateBooking(bookingDetails);

            return RedirectToAction(nameof(MembersController.IndexUser), "Members");

        }
    }
}
