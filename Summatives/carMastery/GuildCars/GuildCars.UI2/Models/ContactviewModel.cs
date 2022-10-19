using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GuildCars.Models.Queries;
using System.ComponentModel.DataAnnotations;

namespace GuildCars.UI2.Models
{
    public class ContactviewModel:IValidatableObject
    {
        public ContactAdd ContactAdd { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if(string.IsNullOrEmpty(ContactAdd.ContactName))
            {
                errors.Add(new ValidationResult("A contact name is required."));
            }
            if(string.IsNullOrEmpty(ContactAdd.ContactMessage))
            {
                errors.Add(new ValidationResult("A message is required."));
            }
            if(string.IsNullOrEmpty(ContactAdd.ContactEmail)&&string.IsNullOrEmpty(ContactAdd.ContactPhoneNumber))
            {
                errors.Add(new ValidationResult("Phone or email must be provided."));
            }

            return errors;

        }
    }
}