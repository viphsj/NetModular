using System;
using  Nm.Lib.Data.Query;

namespace  Nm.Module.PersonnelFiles.Domain.Position.Models
{
    public class PositionQueryModel : QueryModel
    {
        /// <summary>
        /// 部门编码
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
    }
}
