using MVC_SIS_Data;
using MVC_SIS_Models;
using MVC_SIS_UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_SIS_UI.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentAddVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentAddVM studentVM)
        {
            if (!ModelState.IsValid)
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                studentVM.SetStateItems(StateRepository.GetAll());
                return View(studentVM);
            }
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

            StudentRepository.Add(studentVM.Student);

            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentEditVM viewModel = new StudentEditVM
            {
                Student = StudentRepository.Get(id)
            };

            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetStateItems(StateRepository.GetAll());

            if (viewModel.Student.Courses != null)
            {
                viewModel.SelectedCourseIds = (from course in viewModel.Student.Courses
                                               select course.CourseId).ToList();
            }
            else
                viewModel.SelectedCourseIds = new List<int>();

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(StudentEditVM studentVM)
        {
            if(!ModelState.IsValid)
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                studentVM.SetStateItems(StateRepository.GetAll());
                return View(studentVM);
            }
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
            StudentRepository.Edit(studentVM.Student);
            StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
            
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            StudentDeleteVM viewModel = new StudentDeleteVM();
            viewModel.currentStudent = StudentRepository.Get(id);
            //System.Diagnostics.Debug.WriteLine("student selected is " + viewModel.currentStudent.StudentId);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(StudentDeleteVM viewModel)
        {
            StudentRepository.Delete(viewModel.currentStudent.StudentId);
            return RedirectToAction("List");
        }
    }
}