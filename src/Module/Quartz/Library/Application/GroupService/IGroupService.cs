using System;
using System.Threading.Tasks;
using Nm.Lib.Utils.Core.Result;
using Nm.Module.Quartz.Application.GroupService.ViewModels;
using Nm.Module.Quartz.Domain.Group.Models;

namespace Nm.Module.Quartz.Application.GroupService
{
    /// <summary>
    /// 任务组服务
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Query(GroupQueryModel model);

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IResultModel> Add(GroupAddModel model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        Task<IResultModel> Delete(Guid id);

        /// <summary>
        /// 下拉列表
        /// </summary>
        /// <returns></returns>
        Task<IResultModel> Select();
    }
}
