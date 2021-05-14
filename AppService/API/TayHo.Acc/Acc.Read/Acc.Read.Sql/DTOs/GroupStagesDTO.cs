using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class GroupStagesDTO : SysDTOBase
    {
        public int? GroupId { get; set; }
        public int? StageId { get; set; }
    }
}
