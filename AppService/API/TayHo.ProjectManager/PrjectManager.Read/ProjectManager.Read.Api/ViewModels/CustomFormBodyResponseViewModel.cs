using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class CustomFormBodyResponseViewModel : BaseResponseViewModel
    {
        public byte? Priority { get; set; }
        public string Header { get; set; }
        public int? CustomTableId { get; set; }
        public int? CustomFormId { get; set; }
    }
}
