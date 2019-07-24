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
    /// <summary>
    /// AddressTypeのCRUD
    /// </summary>
    public class AddressTypeController : ApiController
    {
        /// <summary>
        /// AddressTypeを全て取得
        /// </summary>
        /// <returns></returns>
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
                    name_in = new[] { "現住所", "本籍" },
                    name_ni = new[] { "旧住所" },
                    removed_at_isnull = true,
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
