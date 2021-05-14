using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class GroupsDTO : SysDTOBase
    {
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public byte? Type { get; set; }
    }
}
