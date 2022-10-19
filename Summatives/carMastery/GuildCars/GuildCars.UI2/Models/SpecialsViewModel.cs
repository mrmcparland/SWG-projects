using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI2.Models
{
    public class SpecialsViewModel:IValidatableObject
    {
        
        public List<Specials> SpecialsList { set; get; }
        public Specials addSpecial { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            
            if(string.IsNullOrEmpty(addSpecial.SpecialTitle))
            {
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
                errors.Add(new ValidationResult("Title is required"));
            }

            return errors;
        }
    }
}