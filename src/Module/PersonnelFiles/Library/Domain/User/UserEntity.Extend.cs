using Nm.Lib.Data.Abstractions.Attributes;
using Nm.Lib.Utils.Core.Extensions;

namespace Nm.Module.PersonnelFiles.Domain.User
{
    public partial class UserEntity
    {
        /// <summary>
        /// ��������
        /// </summary>
        [Ignore]
        public string DepartmentName { get; set; }

        /// <summary>
        /// ��λ����
        /// </summary>
        [Ignore]
        public string PositionName { get; set; }

        /// <summary>
        /// �Ա�����
        /// </summary>
        [Ignore]
        public string SexName => Sex.ToDescription();
    }
}
