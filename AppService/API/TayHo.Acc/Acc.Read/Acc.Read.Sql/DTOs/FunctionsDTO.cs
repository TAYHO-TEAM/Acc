using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class FunctionsDTO : SysDTOBase
    {
        public int? ActionId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int? CategoryId { get; set; }
        public int? Level { get; set; }
    }
}
