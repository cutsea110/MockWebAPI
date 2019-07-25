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
	/// ロール権限のWebAPI
	/// </summary>
	[RoutePrefix("api/rolepermission")]
	public partial class RolePermissionController : ApiController
	{
		/// <summary>
		/// ロール権限の検索
		/// </summary>
		/// <param name="c"></param>
		/// <returns></returns>
		[HttpGet, Route("search")]
		public IEnumerable<RolePermission> Search([FromUri]RolePermissionCondition c)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var list =
					c == null ? db.RolePermission.ToList() :
					db.RolePermission.Where(c.CreatePredicate()).ToList();
				return list;
			}
		}

		/// <summary>
		/// ロール権限の取得
		/// </summary>
		/// <param name="roleId">ロールID(role_id)</param>
		/// <param name="permissionId">権限ID(permission_id)</param>
		/// <returns></returns>
		[HttpGet, Route("get/{roleId}/{permissionId}")]
		public RolePermission Get(string roleId, string permissionId)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var o = db.RolePermission.Find(roleId, permissionId);
				return o;
			}
		}

		/// <summary>
		/// ロール権限の作成
		/// </summary>
		/// <param name="o"></param>
		/// <returns>uid</returns>
		[HttpPost, Route("create")]
		public int Post([FromBody]RolePermission o)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				int uid = (int)db.InsertWithIdentity<RolePermission>(o);
				return uid;
			}
		}

		/// <summary>
		/// ロール権限の更新
		/// </summary>
		/// <param name="roleId">ロールID(role_id)</param>
		/// <param name="permissionId">権限ID(permission_id)</param>
		/// <param name="o"></param>
		/// <returns>更新件数</returns>
		[HttpPut, Route("modify/{roleId}/{permissionId}")]
		public int Modify(string roleId, string permissionId, [FromBody]RolePermission o)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var count = db.Update<RolePermission>(o);
				return count;
			}
		}

		/// <summary>
		/// ロール権限の削除(物理)
		/// </summary>
		/// <param name="roleId">ロールID(role_id)</param>
		/// <param name="permissionId">権限ID(permission_id)</param>
		[HttpDelete, Route("remove/{roleId}/{permissionId}")]
		public int Remove(string roleId, string permissionId)
		{
#if DEBUG
			DataConnection.TurnTraceSwitchOn();
			DataConnection.WriteTraceLine = (msg, context) => Debug.WriteLine(msg, context);
#endif
			using (var db = new peppaDB())
			{
				var o = db.RolePermission.Find(roleId, permissionId);
				var count = db.Delete<RolePermission>(o);
				return count;
			}
		}
	}
}
