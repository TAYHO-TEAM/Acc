using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class OperationProcessDTO : SysDTOBase
    {
        public string Code { get; set; }
        public string BarCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte? Priority { get; set; }
        public int? ParentId { get; set; }
        public int? Level { get; set; }
        public int? PreviousId { get; set; }
        public int? NextId { get; set; }
    }
}
