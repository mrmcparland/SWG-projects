using GuildCars.Data2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI2.Controllers
{
    public class SpecialsController : Controller
    {
        // GET: Specials
        
        public ActionResult Index()
        {
            var repo = SpecialRepositoryFactory.GetRepository().GetAll();
            return View(repo);
        }
    }
}