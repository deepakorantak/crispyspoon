using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrispySpoon.API.Controllers
{
    public class CafeteriaController : ApiController
    {
        crispyspoonDBEntities db = new crispyspoonDBEntities();

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            try
            {
                var cafe = db.tbm_cafeteria.ToList().Select(s => s.cafeteria_name);
                return cafe;
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                Debug.Write(s);

                throw;
            }

            //return cafe;
            //return new string[] { "value1", "value2" };
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