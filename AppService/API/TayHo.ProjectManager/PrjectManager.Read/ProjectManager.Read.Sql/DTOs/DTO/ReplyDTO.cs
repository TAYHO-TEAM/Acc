using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class ReplyDTO : DTOBase
    {
        public int? RequestDetailId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public byte? NoAttachment { get; set; }
    }
}
