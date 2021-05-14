using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class ActionsDTO : SysDTOBase
    {
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int? CategoryId { get; set; }
        public int? Level { get; set; }
        public byte? Priority { get; set; }
    }
}
