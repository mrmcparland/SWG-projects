using dvdLibrary.Data.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dvdLibrary.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = dvdRepositoryFactory.GetRepository().GetDvds();
            return View(model);
        }

        
    }
}