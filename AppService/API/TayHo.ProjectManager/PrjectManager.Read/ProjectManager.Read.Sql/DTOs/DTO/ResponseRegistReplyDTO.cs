using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class ResponseRegistReplyDTO : DTOChilCountBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReplyAccountId { get; set; }
        public int? ResponseRegitId { get; set; }
        public byte? NoAttachment { get; set; }
    }
}
