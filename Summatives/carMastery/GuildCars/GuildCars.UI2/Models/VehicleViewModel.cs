using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI2.Models
{
    public class VehicleViewModel : IValidatableObject
    {
        public Vehicles Vehicles { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public IEnumerable<SelectListItem> Make { get; set; }
        public IEnumerable<SelectListItem> Model { get; set; }
        public IEnumerable<SelectListItem> newOrUsed { get; set; }
        public IEnumerable<SelectListItem> BodyStyle { get; set; }
        public IEnumerable<SelectListItem> transmission { get; set; }
        public IEnumerable<SelectListItem> intColor { get; set; }
        public IEnumerable<SelectListItem> extColor { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if(Vehicles.VehicleYear < 2000 || Vehicles.VehicleYear > DateTime.Now.Year + 1)
            {
                errors.Add(new ValidationResult("Vehicle year should be between 2000 and current year plus one"));
            }
            if (Vehicles.NewOrUsed == "Used" && Vehicles.Mileage < 1000)
            {
                errors.Add(new ValidationResult("Vehicles with less than 1000 miles are considered New"));
            }

                if (Vehicles.NewOrUsed == "New" && Vehicles.Mileage >= 1000)  
            {
                errors.Add(new ValidationResult("Vehicles with more than 1000 miles are considered Used"));
            }
            if(Vehicles.MSRP <=0 || Vehicles.SalesPrice <=0)
            {
                errors.Add(new ValidationResult("MSRP and Sales Price values must be positive"));
            }
            if(Vehicles.SalesPrice > Vehicles.MSRP)
            {
                errors.Add(new ValidationResult("Sales prices may not exceed MSRP"));
            }
            if (string.IsNullOrEmpty(Vehicles.VIN))
            {
                errors.Add(new ValidationResult("VIN is required"));
            }
            if (string.IsNullOrEmpty(Vehicles.VehicleDescription))
            {
                errors.Add(new ValidationResult("Description is required"));
            }
            if (ImageUpload == null && Vehicles.VehicleImage == null)
            {
                errors.Add(new ValidationResult("A vehicle picture is required"));
            }
            return errors;
            
        }
    }
}