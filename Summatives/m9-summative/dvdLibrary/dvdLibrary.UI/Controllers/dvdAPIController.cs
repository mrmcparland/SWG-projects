using dvdLibrary.Data.Factory;
using System.Web.Http.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using dvdLibrary.Models.queries;

namespace dvdLibrary.UI.Controllers
{
    // Allow CORS for all origins. (Caution!)

    //[DisableCors]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class dvdAPIController : ApiController
    {

        //[Route("https://localhost:44335/api/dvdAPIController/dvds")]
        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAllDVDs()
        {
            var repo = dvdRepositoryFactory.GetRepository().GetDvds();
            return Ok(repo);    


        }
        [Route("dvd/title/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByTitle(string dvdTitle)
        {
            var repo = dvdRepositoryFactory.GetRepository().GetByTitle(dvdTitle);
            //Console.WriteLine(repo.dvdTitle);

            return Ok(repo);
        }
        [Route("dvd/id/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdById(int dvdId)
        {
            var repo = dvdRepositoryFactory.GetRepository().GetbyId(dvdId);

            return Ok(repo);
        }

        [Route("dvd/rating/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByRating(string rating)
        {
            var repo = dvdRepositoryFactory.GetRepository().GetByRating(rating);

            return Ok(repo);
        }

        [Route("dvd/director/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdByDirector(string director)
        {
            var repo = dvdRepositoryFactory.GetRepository().GetByDirector(director);

            return Ok(repo);
        }





        [Route("dvd/")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult deleteDVD(int dvdId)
        {
            var repo = dvdRepositoryFactory.GetRepository();
            try
            {
                repo.delete(dvdId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        
        [Route("dvd/add/")]
        [AcceptVerbs("POST")]
        public IHttpActionResult addDVD(dvdRequest dvd)
        {
            var repo = dvdRepositoryFactory.GetRepository();

            

            try
            {
                repo.insert(dvd);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [Route("dvd/edit/")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult editDVD(dvdRequest dvd)
        {
            var repo = dvdRepositoryFactory.GetRepository();

            
            try
            {
                repo.update(dvd);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        

        
    }
}
