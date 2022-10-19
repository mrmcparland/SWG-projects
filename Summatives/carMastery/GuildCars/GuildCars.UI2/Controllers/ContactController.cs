using GuildCars.Data2.ADO;
using GuildCars.Data2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuildCars.Models.Queries;
using GuildCars.UI2.Models;


namespace GuildCars.UI2.Controllers
{
    public class ContactController : Controller
    {
        
        [HttpGet]
        [Route("Contact")]
        [Route("/Contact/{vin}")]
        public ActionResult Index(string vin)
        {
            //Create Blank Contact Object - Populate Message Property - Pass to Page
            var model = vin;
            return View(model);
        }

        //POST
        [HttpPost]
        public ActionResult Index (ContactviewModel contactviewModel, string ContactMessage)
        {
            var repo = ContactRepositoryFactory.GetRepository();
            contactviewModel.ContactAdd.ContactMessage = ContactMessage;
            //contactviewModel.ContactAdd.ContactMessage = 

            if(!ModelState.IsValid)
            {
                contactviewModel = new ContactviewModel();

                return View(contactviewModel);
            }
            try
            {
                repo.addContact(contactviewModel.ContactAdd);
                return RedirectToAction("Index", "Contact");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}