using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class GroupActionPermistionDTO : SysDTOBase
    {
        public int? ActionId { get; set; }
        public int? PermistionId { get; set; }
        public int? GroupId { get; set; }
    }
}
