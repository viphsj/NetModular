﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Nm.Lib.Data.Abstractions;
using Nm.Lib.Utils.Core.Result;
using Nm.Module.Admin.Domain.AuditInfo.Models;

namespace Nm.Module.Admin.Domain.AuditInfo
{
    /// <summary>
    /// 审计信息仓储
    /// </summary>
    public interface IAuditInfoRepository : IRepository<AuditInfoEntity>
    {
        Task<IList<AuditInfoEntity>> Query(AuditInfoQueryModel model);

        Task<AuditInfoEntity> Details(int id);

        /// <summary>
        /// 查询最近一周访问量
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ChatDataRow>> QueryLatestWeekPv();
    }
}
