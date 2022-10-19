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
    public class SalesReportAPIController : ApiController
    {
        [Route("api/SalesReport/Index")]
        [AcceptVerbs("GET")]
        public IHttpActionResult getSalesSearch(string userName, DateTime? minDate, DateTime? maxDate)
        {
            var repo = SalesRepositoryFactory.GetRepository();

            try
            {
                var parameters = new SalesSearchParameters()
                {
                    userName = userName,
                    minDate = minDate,
                    maxDate = maxDate

                };
                var result = repo.GetWithParams(parameters);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
