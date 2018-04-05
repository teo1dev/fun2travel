using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fun2travel.Models
{
    public class CalendarValidatorEndEdit : ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            var model = (ViewModels.BookingDetailVM)validationContext.ObjectInstance;
            DateTime _bookingDateStart = Convert.ToDateTime(model.SelectedDateFrom);
            DateTime _bookingDateEnd = Convert.ToDateTime(model.SelectedDateTo);

            if (_bookingDateStart > _bookingDateEnd)
            {
                return new ValidationResult
                    ("Please choose a later end date.");
            }
            else if (_bookingDateEnd == _bookingDateStart)
            {
                return new ValidationResult
                    ("Please book at least one night.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }

    }
}
