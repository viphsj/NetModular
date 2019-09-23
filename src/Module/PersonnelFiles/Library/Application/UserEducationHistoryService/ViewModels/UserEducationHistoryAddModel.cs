using System;
using System.ComponentModel.DataAnnotations;

namespace Nm.Module.PersonnelFiles.Application.UserEducationHistoryService.ViewModels
{
    public class UserEducationHistoryAddModel
    {
        /// <summary>
        /// 用户编号
        /// </summary>
        [Required(ErrorMessage = "请选择用户")]
        public Guid UserId { get; set; }

        /// <summary>
        /// 学校名称
        /// </summary>
        [Required(ErrorMessage = "请输入学校名称")]
        public string SchoolName { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        [Required(ErrorMessage = "请输入起始日期")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        [Required(ErrorMessage = "请输入结束日期")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public string Profession { get; set; }
    }
}
