using Nm.Lib.Data.Abstractions.Attributes;

namespace Nm.Module.PersonnelFiles.Domain.Department
{
    public partial class DepartmentEntity
    {
        /// <summary>
        /// ����������
        /// </summary>
        [Ignore]
        public string LeaderName { get; set; }
    }
}
