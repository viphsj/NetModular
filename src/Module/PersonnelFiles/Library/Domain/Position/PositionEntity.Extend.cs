using Nm.Lib.Data.Abstractions.Attributes;

namespace Nm.Module.PersonnelFiles.Domain.Position
{
    public partial class PositionEntity
    {
        /// <summary>
        /// ��������
        /// </summary>
        [Ignore]
        public string DepartmentName { get; set; }

        /// <summary>
        /// ��˾��λ
        /// </summary>
        [Ignore]
        public string CompanyName { get; set; }
    }
}
