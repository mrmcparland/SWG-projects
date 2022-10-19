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
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }
        [HttpGet]
        public ActionResult States()

        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }
        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }
        [HttpGet]
        public ActionResult AddState()
        {
            return View(new AddStateVM());
        }
        [HttpPost]
        public ActionResult AddState(AddStateVM viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }
            StateRepository.Add(viewModel.currentState.StateName, viewModel.currentState.StateAbbreviation);
            return RedirectToAction("States");
        }
        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new AddEditMajorVM());
        }

        [HttpPost]
        public ActionResult AddMajor(AddEditMajorVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            MajorRepository.Add(viewModel.currentMajor.MajorName);
            return RedirectToAction("Majors");
        }
        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new AddEditCourseVM());
        }
        [HttpPost]
        public ActionResult AddCourse(AddEditCourseVM viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }
            CourseRepository.Add(viewModel.course.CourseName);
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            AddEditMajorVM viewmodel = new AddEditMajorVM();
            viewmodel.currentMajor = MajorRepository.Get(id);
            System.Diagnostics.Debug.WriteLine("ID retrieved is " + viewmodel.currentMajor.MajorName);
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult EditMajor(AddEditMajorVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            MajorRepository.Edit(viewModel.currentMajor);
            return RedirectToAction("Majors");
        }
        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            AddEditCourseVM viewmodel = new AddEditCourseVM();
            viewmodel.course = CourseRepository.Get(id);
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult EditCourse(AddEditCourseVM viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }
            CourseRepository.Edit(viewModel.course);
            return RedirectToAction("Courses");
        }

        [HttpGet]
        public ActionResult EditState(string abbr)
        {
            AddStateVM viewModel = new AddStateVM();
            System.Diagnostics.Debug.WriteLine("Abbr is " + abbr);
            viewModel.currentState = StateRepository.Get(abbr);
            //System.Diagnostics.Debug.WriteLine("State to edit is: " + viewModel.currentState.StateAbbreviation);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditState(AddStateVM viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }
            StateRepository.Edit(viewModel.currentState);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            DeleteMajorVM viewModel = new DeleteMajorVM();
            viewModel.currentMajor = MajorRepository.Get(id);
            System.Diagnostics.Debug.WriteLine("Major selected is " + viewModel.currentMajor.MajorName);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeleteMajor(DeleteMajorVM viewModel)
        {
            
            MajorRepository.Delete(viewModel.currentMajor.MajorId);
            
            return RedirectToAction("Majors");
        }
        [HttpGet]
        public ActionResult DeleteState(string abbr)
        {
            DeleteStateVM viewModel = new DeleteStateVM();
            viewModel.currentState = StateRepository.Get(abbr);
            //System.Diagnostics.Debug.WriteLine("State selected is " + viewModel.currentState.StateName);
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult DeleteState(DeleteStateVM viewModel)
        {
            //System.Diagnostics.Debug.WriteLine("State being deleted is " + viewModel.currentState);
            StateRepository.Delete(viewModel.currentState.StateAbbreviation);
            
            return RedirectToAction("States");
        }
        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            DeleteCourseVM viewmodel = new DeleteCourseVM();
            viewmodel.course = CourseRepository.Get(id);
            return View(viewmodel);
        }
        [HttpPost]
        public ActionResult DeleteCourse(DeleteCourseVM viewModel)
        {
            CourseRepository.Delete(viewModel.course.CourseId);

            return RedirectToAction("Courses");
        }

        
    }
}