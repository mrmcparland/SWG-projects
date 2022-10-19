using GuildCars.Data2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI2.Controllers
{
    public class UsedVehicleController : Controller
    {
        // GET: UsedVehicle
        public ActionResult UsedInventory()
        {
            var model = VehicleRepositoryFactory.GetRepository();
            return View(model.GetAll());
        }

        public ActionResult UsedInventoryDetail(int VehicleID)
        {
            var model = VehicleRepositoryFactory.GetRepository();

            return View(model.GetById(VehicleID));
        }
        
    }
}