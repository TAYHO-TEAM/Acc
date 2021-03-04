using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class ConversationDTO : DTOBase
    {
        public string OwnerTable { get; set; }
        public int? TopicId { get; set; }
        public int? ParentId { get; set; }
        public string Content { get; set; }
    }
}
