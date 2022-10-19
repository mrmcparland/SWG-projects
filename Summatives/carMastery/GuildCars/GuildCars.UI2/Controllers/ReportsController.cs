using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI2.Controllers
{
    public class ReportsController : Controller
    {
        [Authorize(Roles = "Admin")]
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
    }
}