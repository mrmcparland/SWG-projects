using GuildCars.Data2.Factories;
using GuildCars.UI2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI2.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {

            var model = new VehicleAndSpecialsView();

            model.Vehicles = VehicleRepositoryFactory.GetRepository().GetFeatured();
            model.Specials = SpecialRepositoryFactory.GetRepository().GetAll();
            

            return View(model);
        }

        
       


    }
}