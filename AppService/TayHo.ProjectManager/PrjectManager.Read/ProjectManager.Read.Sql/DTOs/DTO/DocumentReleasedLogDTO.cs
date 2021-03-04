using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class DocumentReleasedLogDTO : DTOBase
    {
        public int? AccountId { get; set; }
        public int? DocumentReleasedId { get; set; }
        public string Note { get; set; }
    }
    public class DocumentReleasedLogDetailDTO : DocumentReleasedLogDTO
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? ProjectId { get; set; }
        public int? WorkItemId { get; set; }
        public string TagWorkItem { get; set; }
        public byte? NoAttachment { get; set; }
        public string AccountName { get; set; }
    }
}
