using GuildCars.Data2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI2.Controllers
{
    public class SalesReportController : Controller
    {
        // GET: SalesReport
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var repo = SalesRepositoryFactory.GetRepository().GetAll();
            return View(repo);
        }
    }
}