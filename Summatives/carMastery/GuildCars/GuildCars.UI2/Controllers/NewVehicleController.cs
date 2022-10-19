using GuildCars.Data2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI2.Controllers
{
    public class NewVehicleController : Controller
    {
        // GET: NewVehicle
        public ActionResult NewInventory()
        {
            var model = VehicleRepositoryFactory.GetRepository();
            return View(model.GetAll());
        }

        public ActionResult NewInventoryDetail(int VehicleID)
        {
            var model = VehicleRepositoryFactory.GetRepository();

            return View(model.GetById(VehicleID));
        }
    }
}