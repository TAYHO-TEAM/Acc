using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NotifyTemplateDTO : DTOBase
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
