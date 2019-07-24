using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LinqToDB;
using LinqToDB.Data;
using peppa.Domain;

namespace MockWebAPI.Controllers
{
    public class AddressTypeController : ApiController
    {
        // GET: api/AddressType
        public IEnumerable<AddressType> Get()
        {
#if DEBUG
            DataConnection.TurnTraceSwitchOn();
            DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
            using (var db = new peppaDB())
            {
                var cond = new AddressTypeCondition
                {
                    address_type_id_ge = 0,
                };
                return db.AddressType.Where(cond.CreatePredicate()).ToList();
            }
        }

        // GET: api/AddressType/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/AddressType
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AddressType/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AddressType/5
        public void Delete(int id)
        {
        }
    }
}
