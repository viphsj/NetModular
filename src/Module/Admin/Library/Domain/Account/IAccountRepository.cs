﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nm.Lib.Auth.Abstractions;
using Nm.Lib.Data.Abstractions;
using Nm.Module.Admin.Domain.Account.Models;

namespace Nm.Module.Admin.Domain.Account
{
    /// <summary>
    /// 账户仓储
    /// </summary>
    public interface IAccountRepository : IRepository<AccountEntity>
    {
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id">账户编号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Task<bool> UpdatePassword(Guid id, string password);

        /// <summary>
        /// 根据用户名查询账户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="type">账户类型</param>
        /// <returns></returns>
        Task<AccountEntity> GetByUserName(string userName, AccountType type);

        /// <summary>
        /// 修改登录信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ip"></param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        Task<bool> UpdateLoginInfo(Guid id, string ip, AccountStatus status = AccountStatus.UnKnown);

        /// <summary>
        /// 查询账户列表
        /// </summary>
        /// <returns></returns>
        Task<IList<AccountEntity>> Query(AccountQueryModel model);

        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="id">编号</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        Task<bool> ExistsUserName(string userName, Guid? id = null, AccountType type = AccountType.Admin);

        /// <summary>
        /// 手机号是否存在
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="id">编号</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        Task<bool> ExistsPhone(string phone, Guid? id = null, AccountType type = AccountType.Admin);

        /// <summary>
        /// 邮箱是否存在
        /// </summary>
        /// <param name="email">邮箱</param>
        /// <param name="id">编号</param>
        /// <param name="type">类型</param>
        /// <returns></returns>
        Task<bool> ExistsEmail(string email, Guid? id = null, AccountType type = AccountType.Admin);
    }
}
