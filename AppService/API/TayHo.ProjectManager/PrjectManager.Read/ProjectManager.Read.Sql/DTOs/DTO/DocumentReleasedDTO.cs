using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class DocumentReleasedDTO : DTOBase
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? ProjectId { get; set; }
        public int? WorkItemId { get; set; }
        public string TagWorkItem { get; set; }
        public string Location { get; set; }
        public DateTime? Calender { get; set; }
        public byte? NoAttachment { get; set; }
    }
}
