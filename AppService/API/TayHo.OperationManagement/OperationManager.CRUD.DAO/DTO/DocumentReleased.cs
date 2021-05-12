using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;

namespace OperationManager.CRUD.DAL.DTO
{
    public class DocumentReleased : DOBase
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? ProjectId { get; set; }
        public int? WorkItemId { get; set; }
        public string TagWorkItem { get; set; }
        public string Location { get; set; }
        public DateTime? Calendar { get; set; }
        public byte? NoAttachment { get; set; }
    }
}
