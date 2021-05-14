using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class RelationTableDTO : SysDTOBase
    {
        public string PrimaryTable { get; set; }
        public string PrimaryKey { get; set; }
        public string ForeignTable { get; set; }
        public string ForeignKey { get; set; }
    }
}
