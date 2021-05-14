using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class GroupStagesDTO : DTOBase
    {
        public int? GroupId { get; set; }
        public int? StageId { get; set; }
    }
}
