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
    public class UnsoldAPIController : ApiController
    {
        [Route("api/unsoldInventory/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult getUnsoldSearch(string yearMakeModel, decimal? minPrice, decimal? maxPrice, int? minYear, int? maxYear)
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
                var result = repo.SearchNotSold(parameters);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/sales/index/{vehicleID}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult getUnsoldDetails(int VehicleID)
        {
            var repo = VehicleRepositoryFactory.GetRepository().GetById(VehicleID);

            if (repo.isSold == "Yes")
            {
                RedirectToRoute("getUnsoldSearch", "api/unsoldInventory/search");
            }

            return Ok(repo);
        }

        
    }
}
