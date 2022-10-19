using GuildCars.Data2.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI2.Controllers
{
    public class AdminEditAPIController : ApiController
    {
        [Route("api/EditVehicle/Admin/{MakeID}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult getModel(int MakeID)
        {
            var repo = VehicleRepositoryFactory.GetRepository().getVehicleModel(MakeID);

            return Ok(repo);
        }
    }
}
