using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class StagesDTO : DTOBase
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
    }
}
