﻿using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Nm.Lib.Data.Abstractions;
using Nm.Lib.Data.Core;
using Nm.Module.Admin.Domain.MenuPermission;

namespace Nm.Module.Admin.Infrastructure.Repositories.SqlServer
{
    public class MenuPermissionRepository : RepositoryAbstract<MenuPermissionEntity>, IMenuPermissionRepository
    {
        public MenuPermissionRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> ExistsBindPermission(string permissionCode)
        {
            return Db.Find(m => m.PermissionCode.Equals(permissionCode)).ExistsAsync();
        }

        public Task<bool> DeleteByPermission(string permissionCode, IDbTransaction transaction)
        {
            return Db.Find(e => e.PermissionCode == permissionCode).UseTran(transaction).DeleteAsync();
        }

        public Task<bool> DeleteByMenu(string menuCode, IDbTransaction transaction)
        {
            return Db.Find(e => e.MenuCode == menuCode).UseTran(transaction).DeleteAsync();
        }

        public Task<IList<MenuPermissionEntity>> GetListByMenu(string menuCode)
        {
            return Db.Find(e => e.MenuCode == menuCode).ToListAsync();
        }
    }
}
