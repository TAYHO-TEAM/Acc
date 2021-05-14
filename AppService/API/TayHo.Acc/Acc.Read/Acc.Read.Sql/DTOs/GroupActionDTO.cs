using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class GroupActionDTO : SysDTOBase
    {
        public int? GroupId { get; set; }
        public int? ActionId { get; set; }
    }
}
