using GuildCars.Data2.Factories;
using GuildCars.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GuildCars.UI2.Controllers
{
    public class UsedVehicleAPIController : ApiController
    {
        
        [Route("api/UsedInventory/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult getUsedSearch(string yearMakeModel, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
        {
            var repo = VehicleRepositoryFactory.GetRepository();

            try
            {
                var parameters = new VehicleSearchParameters()
                {
                    YearMakeModel = yearMakeModel,
                    minPrice = minPrice,
                    maxPrice = maxPrice,
                    maxYear = maxYear,
                    minYear = minYear
                };
                var result = repo.SearchUsed(parameters);
                return Ok(result); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [Route("api/UsedInventory/UsedDetails/{vehicleID}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult getUsedDetails(int VehicleID)
        {
            var repo = VehicleRepositoryFactory.GetRepository().GetById(VehicleID);

             return Ok(repo);
        }
    }
}
