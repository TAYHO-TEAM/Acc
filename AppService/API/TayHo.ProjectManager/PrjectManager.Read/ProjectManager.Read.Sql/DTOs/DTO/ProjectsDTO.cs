using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class ProjectsDTO : DTOBase
    {
        public string Code { get; set; }
        public string BarCode { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public int? ParentId { get; set; }
        public int? NodeLevel { get; set; }
        public int? OldId { get; set; }
    }
}
