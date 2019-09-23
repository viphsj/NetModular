using System;
using System.ComponentModel.DataAnnotations;

namespace Nm.Module.Common.Application.DictService.ViewModels
{
    /// <summary>
    /// 字典添加模型
    /// </summary>
    public class DictUpdateModel
    {
        [Required(ErrorMessage = "请选择要修改的字典")]
        public Guid Id { get; set; }

            /// <summary>
        /// 父节点
        /// </summary>
        public Guid ParentId { get; set; }

            /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

            /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

            /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

    
    }
}
