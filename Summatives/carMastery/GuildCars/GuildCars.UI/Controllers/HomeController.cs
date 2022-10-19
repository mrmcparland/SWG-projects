using GuildCars.Data2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = VehicleRepositoryFactory.GetRepository().GetNew();
            return View(model);
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}