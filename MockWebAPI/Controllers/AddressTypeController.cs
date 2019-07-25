using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using LinqToDB;
using LinqToDB.Data;
using peppa.Domain;

namespace MockWebAPI.Controllers
{
    /// <summary>
    /// 住所種別のAPI
    /// </summary>
    public class AddressTypeController : ApiController
    {
        /// <summary>
        /// 住所の検索
        /// GET: api/AddressType
        /// </summary>
        /// <param name="c">AddressTypeCondition</param>
        /// <returns>検索条件に合致するAddressTypeのリスト</returns>
        public IEnumerable<AddressType> Get([FromUri]AddressTypeCondition c)
        {
#if DEBUG
            DataConnection.TurnTraceSwitchOn();
            DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
            using (var db = new peppaDB())
            {
                var list = db.AddressType.Where(c.CreatePredicate()).ToList();
                return list;
            }
        }

        /// <summary>
        /// 住所の取得
        /// </summary>
        /// <param name="id">住所種別ID</param>
        /// <returns></returns>
        public AddressType Get(int id)
        {
#if DEBUG
            DataConnection.TurnTraceSwitchOn();
            DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
            using (var db = new peppaDB())
            {
                var o = db.AddressType.Find(id);
                return o;
            }
        }

        /// <summary>
        /// 住所の作成
        /// </summary>
        /// <param name="o"></param>
        /// <returns>作成件数</returns>
        public int Post([FromBody]AddressType o)
        {
#if DEBUG
            DataConnection.TurnTraceSwitchOn();
            DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
            using (var db = new peppaDB())
            {
                var count = db.Insert<AddressType>(o);
                return count;
            }
        }

        /// <summary>
        /// 住所の更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="o"></param>
        /// <returns>更新件数</returns>
        public int Put(int id, [FromBody]AddressType o)
        {
#if DEBUG
            DataConnection.TurnTraceSwitchOn();
            DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
            using (var db = new peppaDB())
            {
                var count = db.Update<AddressType>(o);
                return count;
            }
        }

        /// <summary>
        /// 住所の削除(論理)
        /// </summary>
        /// <param name="id"></param>
        public int Delete(int id)
        {
#if DEBUG
            DataConnection.TurnTraceSwitchOn();
            DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
            using (var db = new peppaDB())
            {
                var o = db.AddressType.Find(id);
                o.removed_at = DateTime.Now;
                var count = db.Update<AddressType>(o);
                return count;
            }
        }
    }
}
