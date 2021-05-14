using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class CustomCellContentDTO : DTOBase
    {
        public int? CustomFormContentId { get; set; }
        public int? CustomFormBodyId { get; set; }
        public int? CustomColumId { get; set; }
        public string Contents { get; set; }
        public int? NoRown { get; set; }
    }
}
