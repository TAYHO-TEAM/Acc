using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class RequestsDTO : DTOBase
    {
        public int? ProjectId { get; set; }
        public string Code { get; set; }
        public int? RequestFromId { get; set; }
        public int? StageId { get; set; }
        public byte? Priority { get; set; }
        public int? ReplyById { get; set; }
        public DateTime? SendDateTime { get; set; }
        public byte? NoAttachment { get; set; }
    }
    public class RequestsChildDTO : DTOChilCountBase
    { 
    }
}
