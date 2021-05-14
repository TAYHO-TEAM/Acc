using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class DocumentTypeResponseViewModel : BaseResponseViewModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public int? OperationProcessId { get; set; }
    }
}
