using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;

namespace CrispySpoon.API.V2.Controllers
{
    public class CafeteriaController : ApiController
    {
        CrispySpoonDBEntities dbContext;

        public CafeteriaController()
        {
            dbContext = new CrispySpoonDBEntities();
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            try
            {
                var cafe = dbContext.tbm_cafeteria.ToList().Select(s => s.cafeteria_name);
                return cafe;
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                Debug.Write(s);
                throw;
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}