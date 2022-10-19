using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_SIS_Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_SIS_UI.Models
{
    public class AddEditCourseVM : IValidatableObject
    {
        public Course course { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if(course == null || course.CourseName == "" || course.CourseName == null)
            {
                errors.Add(new ValidationResult("Please enter a Course name",
                    new[] { "course.CourseName" }));
            }

            return errors;
        }
    }
}