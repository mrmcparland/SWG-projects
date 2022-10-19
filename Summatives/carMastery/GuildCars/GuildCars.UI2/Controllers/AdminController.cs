using GuildCars.Data2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuildCars.Models.Tables;
using GuildCars.UI2.Models;
using System.IO;
using GuildCars.UI2.Utilities;
using Microsoft.AspNet.Identity;

namespace GuildCars.UI2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AdminInventory()
        {
            var model = VehicleRepositoryFactory.GetRepository();
            return View(model.GetAll());
        }

        public ActionResult AdminInventoryDetail(int VehicleID)
        {
            var model = VehicleRepositoryFactory.GetRepository();

            return View(model.GetById(VehicleID));
        }
        [HttpGet]
        //[Route("/admin/EditVehicle/{id}")]
        public ActionResult EditVehicle(int id)
        {
            var model = new VehicleViewModel();
            
            model.Vehicles = VehicleRepositoryFactory.GetRepository().GetById(id);
            
            model.Make = new SelectList(VehicleRepositoryFactory.GetRepository().getVehicleMake(), "MakeID", "Make");
            model.BodyStyle = new SelectList(VehicleRepositoryFactory.GetRepository().getBodyStyle(), "BodyStyleID", "BodyStyle");
            model.newOrUsed = new SelectList(VehicleRepositoryFactory.GetRepository().getNewOrUsed(), "newOrUsed", "newOrUsed");
            model.transmission = new SelectList(VehicleRepositoryFactory.GetRepository().getTransmission(), "transmissionType", "transmissionType");
            model.extColor = new SelectList(VehicleRepositoryFactory.GetRepository().getExtColors(), "ExtColorId", "ExtColor");
            model.intColor = new SelectList(VehicleRepositoryFactory.GetRepository().getIntColors(), "IntColorId", "IntColor");
            model.Model = new SelectList(VehicleRepositoryFactory.GetRepository().getVehicleModel(model.Vehicles.MakeID), "ModelID", "Model");

            //model.Vehicles = new Vehicles(); 

            return View(model);
        }
        [HttpPost]
        public ActionResult EditVehicle(VehicleViewModel model)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            //model.Vehicles.DateAdded = DateTime.Now;
            var oldVehicle = repo.GetById(model.Vehicles.VehicleID);
            model.Vehicles.VehicleImage = oldVehicle.VehicleImage;

            if (!ModelState.IsValid)
            {

                model.Vehicles = new Vehicles();
                model.Make = new SelectList(VehicleRepositoryFactory.GetRepository().getVehicleMake(), "MakeID", "Make");
                model.BodyStyle = new SelectList(VehicleRepositoryFactory.GetRepository().getBodyStyle(), "BodyStyleID", "BodyStyle");
                model.newOrUsed = new SelectList(VehicleRepositoryFactory.GetRepository().getNewOrUsed(), "newOrUsed", "newOrUsed");
                model.transmission = new SelectList(VehicleRepositoryFactory.GetRepository().getTransmission(), "transmissionType", "transmissionType");
                model.extColor = new SelectList(VehicleRepositoryFactory.GetRepository().getExtColors(), "ExtColorId", "ExtColor");
                model.intColor = new SelectList(VehicleRepositoryFactory.GetRepository().getIntColors(), "IntColorId", "IntColor");
                model.Model = new SelectList(VehicleRepositoryFactory.GetRepository().getVehicleModel(model.Vehicles.MakeID), "ModelID", "Model");

                model.Vehicles.VehicleImage = oldVehicle.VehicleImage;

                

                return View(model);
            }
            try
            {

                //model.Vehicles.VehicleID = AuthorizeUtilities.GetUserId(this);
                model.Vehicles.VehicleImage = oldVehicle.VehicleImage;

                if (model.ImageUpload != null &&  model.ImageUpload.ContentLength >0)
                {
                    var savepath = Server.MapPath("~/Images");

                    string filename = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                    string extension = Path.GetExtension(model.ImageUpload.FileName);

                    var filepath = Path.Combine(savepath, filename + extension);

                    int counter = 1;
                    while(System.IO.File.Exists(filepath))
                    {
                        filepath = Path.Combine(savepath, filename + counter.ToString() + extension);
                        counter++;
                    }

                    model.ImageUpload.SaveAs(filepath);
                    model.Vehicles.VehicleImage = Path.GetFileName(filepath);

                    var oldpath = Path.Combine(savepath, oldVehicle.VehicleImage);
                    if(System.IO.File.Exists(oldpath))
                    {
                        System.IO.File.Delete(oldpath);
                    }
                }

                else
                {
                    model.Vehicles.VehicleImage = oldVehicle.VehicleImage;
                }

                repo.update(model.Vehicles);

                return RedirectToAction("AdminInventory");
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return RedirectToAction("AdminInventory");

        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            var model = new VehicleViewModel();

            model.Make = new SelectList(VehicleRepositoryFactory.GetRepository().getVehicleMake(), "MakeID", "Make");
            model.BodyStyle = new SelectList(VehicleRepositoryFactory.GetRepository().getBodyStyle(), "BodyStyleID", "BodyStyle");
            model.newOrUsed = new SelectList(VehicleRepositoryFactory.GetRepository().getNewOrUsed(), "newOrUsed", "newOrUsed");
            model.transmission = new SelectList(VehicleRepositoryFactory.GetRepository().getTransmission(), "transmissionType", "transmissionType");
            model.extColor = new SelectList(VehicleRepositoryFactory.GetRepository().getExtColors(), "ExtColorId", "ExtColor");
            model.intColor = new SelectList(VehicleRepositoryFactory.GetRepository().getIntColors(), "IntColorId", "IntColor");
            model.Model = new SelectList(VehicleRepositoryFactory.GetRepository().getVehicleModel(1), "ModelID", "Model");
            model.Vehicles = new Vehicles();
            
            return View(model);
        }
        [HttpPost]
        public ActionResult AddVehicle(VehicleViewModel model)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            model.Vehicles.DateAdded = DateTime.Now;
            model.Vehicles.isSold = "No";

            if (!ModelState.IsValid)
            {
                model.Make = new SelectList(VehicleRepositoryFactory.GetRepository().getVehicleMake(), "MakeID", "Make");
                model.BodyStyle = new SelectList(VehicleRepositoryFactory.GetRepository().getBodyStyle(), "BodyStyleID", "BodyStyle");
                model.newOrUsed = new SelectList(VehicleRepositoryFactory.GetRepository().getNewOrUsed(), "newOrUsed", "newOrUsed");
                model.transmission = new SelectList(VehicleRepositoryFactory.GetRepository().getTransmission(), "transmissionType", "transmissionType");
                model.extColor = new SelectList(VehicleRepositoryFactory.GetRepository().getExtColors(), "ExtColorId", "ExtColor");
                model.intColor = new SelectList(VehicleRepositoryFactory.GetRepository().getIntColors(), "IntColorId", "IntColor");
                model.Model = new SelectList(VehicleRepositoryFactory.GetRepository().getVehicleModel(model.Vehicles.MakeID), "ModelID", "Model");
                model.Vehicles = new Vehicles();

                return View(model);
            }

            try
            {
                if(model.ImageUpload != null && model.ImageUpload.ContentLength >0)
                {
                    var savepath = Server.MapPath("~/Images");

                    //string fileName = Path.GetFileNameWithoutExtension(model.ImageUpload.FileName);
                    string fileName = "Inventory-";
                    string extension = Path.GetExtension(model.ImageUpload.FileName);

                    var filePath = Path.Combine(savepath, fileName + extension);

                    int counter = 1;
                    while (System.IO.File.Exists(filePath))
                    {
                        filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                        counter++;
                    }
                    model.ImageUpload.SaveAs(filePath);
                    model.Vehicles.VehicleImage = Path.GetFileName(filePath);
                }
                repo.insert(model.Vehicles);

                return RedirectToAction("EditVehicle", new { id = model.Vehicles.VehicleID });
            }
            catch(Exception ex)
            {
                throw ex;
            }

            
        }
        [HttpPost]
        public ActionResult DeleteVehicle (int VehicleID)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            var model = VehicleRepositoryFactory.GetRepository().GetById(VehicleID);
            var savepath = Server.MapPath("~/Images");

            string fileName = model.VehicleImage;
            //string extension = Path.GetExtension(model.VehicleImage);

            var filePath = Path.Combine(savepath, fileName);
            
            if(System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            repo.delete(VehicleID);

            return RedirectToAction("AdminInventory");
        }
        public ActionResult AdminSpecial()
        {
            var model = new SpecialsViewModel();
            model.SpecialsList = SpecialRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }
        [HttpPost]
        public ActionResult AddSpecial(SpecialsViewModel specials)
        {
            if (ModelState.IsValid)
            {
                SpecialRepositoryFactory.GetRepository().insert(specials.addSpecial);

                return RedirectToAction("AdminSpecial");
            }

            else
            {
                ModelState.AddModelError(string.Empty, "title is required");
                return RedirectToAction("AdminSpecial");
            }


            
        }
        [HttpPost]
        public ActionResult DeleteSpecial(int specialID)
        {
            var repo = SpecialRepositoryFactory.GetRepository();

            repo.delete(specialID);

            return RedirectToAction("AdminSpecial");
        }
        
        public ActionResult AddMake()
        {
            var model = new MakeViewModel();
            model.MakeList = VehicleRepositoryFactory.GetRepository().GetVehicleMakes();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddMake(MakeViewModel model)
        {
            

            if (!ModelState.IsValid)
            {
                //var model = new MakeViewModel();
                model.MakeList = VehicleRepositoryFactory.GetRepository().GetVehicleMakes();
                return View(model);
            }
            model.vehicleMake.DateAdded = DateTime.Now;
            model.vehicleMake.UserName = User.Identity.GetUserName();
            VehicleRepositoryFactory.GetRepository().insertMake(model.vehicleMake);

            return RedirectToAction("AddMake");
        }
        [HttpGet]
        public ActionResult AddModel()
        {
            var model = new ModelViewModel();
            model.Make = new SelectList(VehicleRepositoryFactory.GetRepository().GetVehicleMakes(), "MakeID", "Make");
            model.ModelList = VehicleRepositoryFactory.GetRepository().GetVehicleModelsAll();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddModel(ModelViewModel model)
        {
            var repo = VehicleRepositoryFactory.GetRepository();
            
            if(!ModelState.IsValid)
            {
                model.Make = new SelectList(VehicleRepositoryFactory.GetRepository().GetVehicleMakes(), "MakeID", "Make");
                model.ModelList = VehicleRepositoryFactory.GetRepository().GetVehicleModelsAll();
                return View(model);
            }
            model.vehicleModel.DateAdded = DateTime.Now;
            model.vehicleModel.UserName = User.Identity.GetUserName();
            
            //model.MakeList = VehicleRepositoryFactory.GetRepository().GetVehicleMakes();

            repo.insertModel(model.vehicleModel);

            return RedirectToAction("AddModel");
        }
    }
}