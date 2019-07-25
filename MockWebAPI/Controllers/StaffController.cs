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
		/// 職員の検索
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		[HttpGet, Route("search")]
		public IEnumerable<Staff> Search([FromUri]StaffCondition c)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var list =
					c == null ? db.Staff.ToList() :
					db.Staff.Where(c.CreatePredicate()).ToList();
				return list;
			}
		}

		/// <summary>
		/// 職員の取得
		/// </summary>
		/// <param name="staffNo">職員番号(staff_no)</param>
		/// <returns></returns>
		[HttpGet, Route("get/{staffNo}")]
		public Staff Get(string staffNo)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var o = db.Staff.Find(staffNo);
				return o;
			}
		}

		/// <summary>
		/// 職員の作成
		/// </summary>
		/// <param name="o"></param>
		/// <returns>作成件数</returns>
		[HttpPost, Route("create")]
		public int Post([FromBody]Staff o)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count = db.Insert<Staff>(o);
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
		[HttpDelete, Route("remove/{staffNo}")]
		public int Remove(string staffNo)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var o = db.Staff.Find(staffNo);
				o.removed_at = DateTime.Now;
				var count = db.Update<Staff>(o);
				return count;
			}
		}
	}
}