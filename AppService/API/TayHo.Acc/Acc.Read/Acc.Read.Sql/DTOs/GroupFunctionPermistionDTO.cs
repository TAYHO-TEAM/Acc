using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class GroupFunctionPermistionDTO : SysDTOBase
    {
        public int? GroupId { get; set; }
        public int? FunctionId { get; set; }
        public int? PermistionId { get; set; }
    }
}
