using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class DocumentReleasedResponseViewModel : BaseResponseViewModel
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
        public bool? Insert { get; set; }
        public bool? Update { get; set; }
        public bool? Delete { get; set; }
        public bool? View { get; set; }
        public string AccountName { get; set; }
    }
}
