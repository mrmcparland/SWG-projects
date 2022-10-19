using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GuildCars.UI2.Models
{
    public class MakeViewModel:IValidatableObject
    {
        public IEnumerable<VehicleMake> MakeList { get; set; }
        public VehicleMake vehicleMake { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(vehicleMake.Make))
            {
                errors.Add(new ValidationResult("A Make is required"));
            }

            return errors;
        }
    }
}