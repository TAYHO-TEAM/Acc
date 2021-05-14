using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class PermistionsDTO : SysDTOBase
    {
        public byte? Type { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
    }
}
