using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class ProblemCategoryDTO : DTOBase
    {
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public byte? Priotity { get; set; }
    }
}
