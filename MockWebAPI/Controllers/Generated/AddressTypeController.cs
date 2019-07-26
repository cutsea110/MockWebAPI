//---------------------------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by peppapig from database table definition.
//	Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------
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
	/// 住所種別のWebAPI
	/// </summary>
	[RoutePrefix("api/addresstype")]
	public partial class AddressTypeController : ApiController
	{

		/// <summary>
		/// 住所種別の件数
		/// </summary>
		/// <param name="c"></param>
		/// <returns>ヒットした件数</returns>
		[HttpGet, Route("count")]
		public int Count([FromUri]AddressTypeCondition c)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count =
					c == null ? db.AddressType.Count() :
					db.AddressType.Count(predicate: c.CreatePredicate());
				return count;
			}
		}

		/// <summary>
		/// 住所種別の検索
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		[HttpGet, Route("search")]
		public IEnumerable<AddressType> Search([FromUri]AddressTypeCondition c)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var q = db.AddressType;
				var list = (c == null ? q : q.Where(c.CreatePredicate())).ToList();
				return list;
			}
		}

		/// <summary>
		/// 住所種別の取得
		/// </summary>
		/// <param name="addressTypeId">住所種別ID(address_type_id)</param>
		/// <returns></returns>
		[HttpGet, Route("get/{addressTypeId}")]
		public AddressType Get(int addressTypeId)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var q = db.AddressType;
				var o = q.Find(addressTypeId);
				return o;
			}
		}

		/// <summary>
		/// 住所種別の作成
		/// </summary>
		/// <param name="o"></param>
		/// <returns>uid</returns>
		[HttpPost, Route("create")]
		public int Create([FromBody]AddressType o)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				int uid = db.InsertWithInt32Identity<AddressType>(o);
				return uid;
			}
		}

		/// <summary>
		/// 住所種別の更新(必要時作成)
		/// </summary>
		/// <param name="o"></param>
		/// <returns>件数</returns>
		[HttpPost, Route("upsert")]
		public int Upsert([FromBody]AddressType o)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				int count = db.InsertOrReplace<AddressType>(o);
				return count;
			}
		}

		/// <summary>
		/// 住所種別の一括作成
		/// </summary>
		/// <param name="os"></param>
		/// <returns>BulkCopyRowsCopied</returns>
		[HttpPost, Route("massive-new")]
		public BulkCopyRowsCopied MassiveCreate([FromBody]IEnumerable<AddressType> os)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var ret = db.BulkCopy<AddressType>(os);
				return ret;
			}
		}

		/// <summary>
		/// 住所種別のマージ
		/// </summary>
		/// <param name="os"></param>
		/// <returns>件数</returns>
		[HttpPost, Route("merge")]
		public int Merge([FromBody]IEnumerable<AddressType> os)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count = db.Merge<AddressType>(os);
				return count;
			}
		}

		/// <summary>
		/// 住所種別の更新
		/// </summary>
		/// <param name="addressTypeId">住所種別ID(address_type_id)</param>
		/// <param name="o"></param>
		/// <returns>更新件数</returns>
		[HttpPut, Route("modify/{addressTypeId}")]
		public int Modify(int addressTypeId, [FromBody]AddressType o)
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
		/// 住所種別の削除(論理)
		/// </summary>
		/// <param name="addressTypeId">住所種別ID(address_type_id)</param>
		/// <returns>件数</returns>
		[HttpDelete, Route("remove/{addressTypeId}")]
		public int Remove(int addressTypeId)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count = db.AddressType
					.Where(_ => _.address_type_id == addressTypeId)
					.Set(_ => _.removed_at, DateTime.Now)
					.Update();
				return count;
			}
		}

		/// <summary>
		/// 住所種別の削除(論理)
		/// </summary>
		/// <param name="c"></param>
		/// <returns>件数</returns>
		[HttpDelete, Route("remove")]
		public int Remove([FromUri]AddressTypeCondition c)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count = db.AddressType
					.Where(c.CreatePredicate())
					.Set(_ => _.removed_at, DateTime.Now)
					.Update();
				return count;
			}
		}

		/// <summary>
		/// 住所種別の物理削除
		/// </summary>
		/// <param name="addressTypeId">住所種別ID(address_type_id)</param>
		/// <returns>件数</returns>
		[HttpDelete, Route("physically-remove/{addressTypeId}")]
		public int PhysicallyRemove(int addressTypeId)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count = db.AddressType
					.Where(_ => _.address_type_id == addressTypeId)
					.Delete();
				return count;
			}
		}

		/// <summary>
		/// 住所種別の物理削除
		/// </summary>
		/// <param name="c"></param>
		/// <returns>件数</returns>
		[HttpDelete, Route("physically-remove")]
		public int PhysicallyRemove([FromUri]AddressTypeCondition c)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count = db.AddressType
					.Where(c.CreatePredicate())
					.Delete();
				return count;
			}
		}
	}
}
