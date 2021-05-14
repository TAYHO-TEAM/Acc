using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class DocumentReleasedAccountDTO : DTOBase
    {
        public int? AccountId { get; set; }
        public int? DocumentReleasedId { get; set; }
        public int? GroupId { get; set; }
    }
}
