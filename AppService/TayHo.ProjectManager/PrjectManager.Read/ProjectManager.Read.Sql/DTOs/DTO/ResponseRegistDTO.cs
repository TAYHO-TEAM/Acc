using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class ResponseRegistDTO : DTOBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? StepProcessId { get; set; }
        public int? RequestRegistId { get; set; }
        public int? GroupId { get; set; }
        public int? ReplyId { get; set; }
        public byte? NoAttachment { get; set; }
        public bool? IsApprove { get; set; }
        public byte? TypeOfResult { get; set; }
        public bool? Insert { get; set; }
        public bool? Update { get; set; }
        public bool? Delete { get; set; }
        public bool? View { get; set; }
        public string AccountName { get; set; }
    }
}
