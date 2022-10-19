using GuildCars.Data2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI2.Controllers
{
    public class InventoryReportController : Controller
    {
        // GET: InventoryReport
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var repo = VehicleRepositoryFactory.GetRepository().GetStockValuesNew();
            return View(repo);
        }
    }
}