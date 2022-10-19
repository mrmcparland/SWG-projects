using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GuildCars.UI2.Models
{
    public class ModelViewModel : IValidatableObject
    {
        public IEnumerable<SelectListItem> Make { get; set; }
        public VehicleModel vehicleModel { get; set; }
        public IEnumerable<VehicleMake> MakeList { get; set; }
        public IEnumerable<VehicleModel> ModelList { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(vehicleModel.Model))
            {
                errors.Add(new ValidationResult("A Model is required"));
            }

            return errors;
        }
    }
}