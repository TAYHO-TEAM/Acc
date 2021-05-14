using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class AssignmentsDTO : DTOBase
    {
        public int AccountId { get; set; }
        public int RequestId { get; set; }
        public int RequestDetailId { get; set; }
    }
}
