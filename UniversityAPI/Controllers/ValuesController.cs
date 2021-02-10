using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UniversityAPI.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]// consultar
        public IHttpActionResult Get() {
          //  return StatusCode(HttpStatusCode.OK);
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult Post()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            
            return Ok();//json
        }
        [HttpPut]
        public IHttpActionResult Put()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

            return Ok();//json
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id == null)
                return NotFound();

            return Ok();

        }
    }
}
