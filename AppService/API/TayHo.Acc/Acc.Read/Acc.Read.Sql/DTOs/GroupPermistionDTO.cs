using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class GroupPermistionDTO : SysDTOBase
    {
        public int? PermistionId { get; set; }
        public int? GroupId { get; set; }
    }
}
