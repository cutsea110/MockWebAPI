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
	/// 職員のWebAPI
	/// </summary>
	[RoutePrefix("api/staff")]
	public partial class StaffController : ApiController
	{

		/// <summary>
		/// 職員の件数
		/// </summary>
		/// <param name="c"></param>
		/// <returns>ヒットした件数</returns>
		[HttpGet, Route("count")]
		public int Count([FromUri]StaffCondition c)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count =
					c == null ? db.Staff.Count() :
					db.Staff.Count(predicate: c.CreatePredicate());
				return count;
			}
		}

		/// <summary>
		/// 職員の検索
		/// </summary>
		/// <param name="with_AccountList">AccountListをLoadWithするか</param>
		/// <param name="with_AddressList">AddressListをLoadWithするか</param>
		/// <param name="with_ContactList">ContactListをLoadWithするか</param>
		/// <param name="c"></param>
		/// <returns></returns>
		[HttpGet, Route("search")]
		public IEnumerable<Staff> Search([FromUri]bool with_AccountList, [FromUri]bool with_AddressList, [FromUri]bool with_ContactList, [FromUri]StaffCondition c)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var q = db.Staff;

				#region LoadWith
				if (with_AccountList)
					q = q.LoadWith(_ => _.AccountList);
				if (with_AddressList)
					q = q.LoadWith(_ => _.AddressList);
				if (with_ContactList)
					q = q.LoadWith(_ => _.ContactList);
				#endregion

				var list = (c == null ? q : q.Where(c.CreatePredicate())).ToList();
				return list;
			}
		}

		/// <summary>
		/// 職員の取得
		/// </summary>
		/// <param name="with_AccountList">AccountListをLoadWithするか</param>
		/// <param name="with_AddressList">AddressListをLoadWithするか</param>
		/// <param name="with_ContactList">ContactListをLoadWithするか</param>
		/// <param name="staffNo">職員番号(staff_no)</param>
		/// <returns></returns>
		[HttpGet, Route("get/{staffNo}")]
		public Staff Get([FromUri]bool with_AccountList, [FromUri]bool with_AddressList, [FromUri]bool with_ContactList, string staffNo)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var q = db.Staff;

				#region LoadWith
				if (with_AccountList)
					q = q.LoadWith(_ => _.AccountList);
				if (with_AddressList)
					q = q.LoadWith(_ => _.AddressList);
				if (with_ContactList)
					q = q.LoadWith(_ => _.ContactList);
				#endregion

				var o = q.Find(staffNo);
				return o;
			}
		}

		/// <summary>
		/// 職員の作成
		/// </summary>
		/// <param name="o"></param>
		/// <returns>uid</returns>
		[HttpPost, Route("create")]
		public int Create([FromBody]Staff o)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				int uid = db.InsertWithInt32Identity<Staff>(o);
				return uid;
			}
		}

		/// <summary>
		/// 職員の更新(必要時作成)
		/// </summary>
		/// <param name="o"></param>
		/// <returns>件数</returns>
		[HttpPost, Route("upsert")]
		public int Upsert([FromBody]Staff o)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				int count = db.InsertOrReplace<Staff>(o);
				return count;
			}
		}

		/// <summary>
		/// 職員の一括作成
		/// </summary>
		/// <param name="os"></param>
		/// <returns>BulkCopyRowsCopied</returns>
		[HttpPost, Route("massive-new")]
		public BulkCopyRowsCopied MassiveCreate([FromBody]IEnumerable<Staff> os)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var ret = db.BulkCopy<Staff>(os);
				return ret;
			}
		}

		/// <summary>
		/// 職員のマージ
		/// </summary>
		/// <param name="os"></param>
		/// <returns>件数</returns>
		[HttpPost, Route("merge")]
		public int Merge([FromBody]IEnumerable<Staff> os)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count = db.Merge<Staff>(os);
				return count;
			}
		}

		/// <summary>
		/// 職員の更新
		/// </summary>
		/// <param name="staffNo">職員番号(staff_no)</param>
		/// <param name="o"></param>
		/// <returns>更新件数</returns>
		[HttpPut, Route("modify/{staffNo}")]
		public int Modify(string staffNo, [FromBody]Staff o)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count = db.Update<Staff>(o);
				return count;
			}
		}

		/// <summary>
		/// 職員の削除(論理)
		/// </summary>
		/// <param name="staffNo">職員番号(staff_no)</param>
		/// <returns>件数</returns>
		[HttpDelete, Route("remove/{staffNo}")]
		public int Remove(string staffNo)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count = db.Staff
					.Where(_ => _.staff_no == staffNo)
					.Set(_ => _.removed_at, DateTime.Now)
					.Update();
				return count;
			}
		}

		/// <summary>
		/// 職員の削除(論理)
		/// </summary>
		/// <param name="c"></param>
		/// <returns>件数</returns>
		[HttpDelete, Route("remove")]
		public int Remove([FromUri]StaffCondition c)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count = db.Staff
					.Where(c.CreatePredicate())
					.Set(_ => _.removed_at, DateTime.Now)
					.Update();
				return count;
			}
		}

		/// <summary>
		/// 職員の物理削除
		/// </summary>
		/// <param name="staffNo">職員番号(staff_no)</param>
		/// <returns>件数</returns>
		[HttpDelete, Route("physically-remove/{staffNo}")]
		public int PhysicallyRemove(string staffNo)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count = db.Staff
					.Where(_ => _.staff_no == staffNo)
					.Delete();
				return count;
			}
		}

		/// <summary>
		/// 職員の物理削除
		/// </summary>
		/// <param name="c"></param>
		/// <returns>件数</returns>
		[HttpDelete, Route("physically-remove")]
		public int PhysicallyRemove([FromUri]StaffCondition c)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count = db.Staff
					.Where(c.CreatePredicate())
					.Delete();
				return count;
			}
		}
	}
}
