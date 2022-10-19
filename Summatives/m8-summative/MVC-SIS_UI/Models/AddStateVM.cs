using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_SIS_Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_SIS_UI.Models
{
    public class AddStateVM:IValidatableObject
    {
        public State currentState { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (currentState == null || currentState.StateName == null || currentState.StateName == "")
            {
                errors.Add(new ValidationResult("Please enter the state name",
                    new[] { "currentState.StateName" }));
            }
            
                


             return errors;
        }
    }
}