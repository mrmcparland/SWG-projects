using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuildCars.Models.Tables;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GuildCars.UI2.Models
{
    public class PurchaseVehicleViewModel : IValidatableObject
    {
        public Vehicles Vehicles { get; set; }
        public VehicleSales VehicleSales { get; set; }
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> PmtType { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if(string.IsNullOrEmpty(VehicleSales.CustomerName))
            {
                errors.Add(new ValidationResult("Customer name is required"));
            }

            if (string.IsNullOrEmpty(VehicleSales.StreetAdd1))
            {
                errors.Add(new ValidationResult("Street address is required"));
            }

            if (string.IsNullOrEmpty(VehicleSales.PhoneNumber) && string.IsNullOrEmpty(VehicleSales.Email))
            {
                errors.Add(new ValidationResult("Phone or email required"));
            }

            if (string.IsNullOrEmpty(VehicleSales.City))
            {
                errors.Add(new ValidationResult("City is required"));
            }
            if(VehicleSales.SalesPrice > Vehicles.MSRP)
            {
                errors.Add(new ValidationResult("Purchase price cannot exceed MSRP"));
            }
            if(VehicleSales.SalesPrice < (Vehicles.SalesPrice * .95M))
            {
                errors.Add(new ValidationResult("Purchase price cannot be less than 95% of sales price "));
            }
            if(Vehicles.isSold == "Yes")
            {
                errors.Add(new ValidationResult("This vehicle has been sold; please navigate to another page"));
            }

            


            return errors;
        }
    }

}