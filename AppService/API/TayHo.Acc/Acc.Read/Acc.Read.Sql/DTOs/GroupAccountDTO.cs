using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class GroupAccountDTO : SysDTOBase
    {
        public int? AccountId { get; set; }
        public int? GroupId { get; set; }
    }
}
