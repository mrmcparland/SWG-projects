using GuildCars.Data2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuildCars.Models.Queries;
using GuildCars.UI2.Models;
using System.IO;
using Microsoft.AspNet.Identity;

namespace GuildCars.UI2.Controllers
{
    [Authorize(Roles = "Sales")]
    public class UnsoldController : Controller
    {
        // GET: Sales
        //[Route("api/sales/index")]
        public ActionResult Index()
        {
            var model = VehicleRepositoryFactory.GetRepository();
            
            return View(model.GetAll());
        }
        //[Route("Unsold/UnsoldInventoryDetail/{id]")]
        //problematic routes?
        public ActionResult UnsoldInventoryDetail(int id)
        {
            
            
            var repo = VehicleRepositoryFactory.GetRepository().GetById(id);

            if(repo.isSold == "Yes")
            {
               return RedirectToAction("Index");
            }

            var model = new PurchaseVehicleViewModel();

            var salesRepo = SalesRepositoryFactory.GetRepository();

            model.Vehicles = VehicleRepositoryFactory.GetRepository().GetById(id);
            //model.VehicleSales.purchasedVehicleID = 1;
            model.States = new SelectList(salesRepo.GetStates(), "StateAbbr", "StateAbbr");
            model.PmtType = new SelectList(salesRepo.GetPmtType(), "PmtOption", "PmtOption");

            return View(model);
        }
        
        [HttpPost]
        public ActionResult UnsoldInventoryDetail(PurchaseVehicleViewModel model)
        {
            //var purchaseVehicle = VehicleRepositoryFactory.GetRepository();
            var salesRepo = SalesRepositoryFactory.GetRepository();

            if (!ModelState.IsValid)
            {
                
                model.States = new SelectList(salesRepo.GetStates(), "StateAbbr", "StateAbbr");
                model.PmtType = new SelectList(salesRepo.GetPmtType(), "PmtOption", "PmtOption");
               
                model.Vehicles = VehicleRepositoryFactory.GetRepository().GetById(model.Vehicles.VehicleID);

                return View(model);
            }
                try
                {
                    var saleRecord = SalesRepositoryFactory.GetRepository();
                    model.VehicleSales.purchasedVehicleID = model.Vehicles.VehicleID;
                    model.VehicleSales.dateOfSale = DateTime.Now;
                    model.VehicleSales.UserName = User.Identity.GetUserName();
           
                    // purchaseVehicle.update(model.Vehicles);
                    saleRecord.salesLog(model.VehicleSales);

                return RedirectToAction("Index");
                    //, new { id = model.Vehicles.VehicleID });
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
        }
        
    }
}