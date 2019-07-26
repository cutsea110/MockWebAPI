using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;

using LinqToDB;
using LinqToDB.Mapping;

using peppa.util;

namespace peppa.Domain
{
    /// <summary>
    /// ロールマスタ
    /// </summary>
    public partial class Role
    {

    }

    /// <summary>
    /// ロールマスタ条件
    /// </summary>
    public partial class RoleCondition
    {
        /// <summary>
        /// LoadWithしている前提
        /// </summary>
        [DataMember]
        public RolePermissionCondition rp { get; set; }

        /// <summary>
        /// 検索条件式の生成
        /// </summary>
        /// <returns></returns>
        public override Expression<Func<Role, bool>> CreatePredicate()
        {
            var predicate = base.CreatePredicate();

            if (rp != null)
                predicate = predicate.And(_ => _.RolePermissionList.AsQueryable().Any(rp.CreatePredicate()));

            return predicate;
        }
    }
}