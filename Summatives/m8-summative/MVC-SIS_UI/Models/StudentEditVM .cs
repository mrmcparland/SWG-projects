using MVC_SIS_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_SIS_UI.Models
{
    public class StudentEditVM:IValidatableObject
    {
        

        public Student Student { get; set; }
        public List<SelectListItem> CourseItems { get; set; }
        public List<SelectListItem> MajorItems { get; set; }
        public List<SelectListItem> StateItems { get; set; }
        public List<int> SelectedCourseIds { get; set; }

        public StudentEditVM()
        {
            CourseItems = new List<SelectListItem>();
            MajorItems = new List<SelectListItem>();
            StateItems = new List<SelectListItem>();
            SelectedCourseIds = new List<int>();
            Student = new Student();
        }

        public void SetCourseItems(IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                CourseItems.Add(new SelectListItem()
                {
                    Value = course.CourseId.ToString(),
                    Text = course.CourseName
                });
            }
        }

        public void SetMajorItems(IEnumerable<Major> majors)
        {
            foreach (var major in majors)
            {
                MajorItems.Add(new SelectListItem()
                {
                    Value = major.MajorId.ToString(),
                    Text = major.MajorName
                });
            }
        }

        public void SetStateItems(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StateItems.Add(new SelectListItem()
                {
                    Value = state.StateAbbreviation,
                    Text = state.StateName
                });
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if(Student.Address.Street1 == null || Student.Address.Street1 == "")
            {
                errors.Add(new ValidationResult("Please input the street address",
                    new[]{ "Student.Address.Street1" }));
            }
            else if(Student.Address.City == null || Student.Address.City =="")
            {
                errors.Add(new ValidationResult("Please input the city",
                    new[] { "Student.Address.City" }));
            }
            else if (Student.Address.PostalCode == "" || Student.Address.PostalCode == null )
            {
                errors.Add(new ValidationResult("Please input a 5 digit zip code",
                    new[] { "Student.Address.PostalCode" }));
            }
            else if (Student.Address.PostalCode.Length != 5)
            {
                errors.Add(new ValidationResult("The zip code must be 5 digits",
                    new[] { "Student.Address.PostalCode" }));
            }

            return errors;
        }
    }
}