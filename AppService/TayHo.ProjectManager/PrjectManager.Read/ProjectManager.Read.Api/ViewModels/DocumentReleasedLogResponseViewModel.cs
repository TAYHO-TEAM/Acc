using ProjectManager.Read.Api.ViewModels.BaseClasses;
using ProjectManager.Read.Sql.DTOs.DTO;
using System.Collections.Generic;

namespace ProjectManager.Read.Api.ViewModels
{
    public class DocumentReleasedLogResponseViewModel : BaseResponseViewModel
    {
        public int? AccountId { get; set; }
        public int? DocumentReleasedId { get; set; }
        public string Note { get; set; }
    }
    public class DocumentReleasedLogDetailResponseViewModel : DocumentReleasedLogResponseViewModel
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
