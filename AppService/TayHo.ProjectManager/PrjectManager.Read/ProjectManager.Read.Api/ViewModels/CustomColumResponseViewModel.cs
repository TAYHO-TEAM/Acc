using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class CustomColumResponseViewModel : BaseResponseViewModel
    {
        public int? CustomTableId { get; set; }
        public int? ColIndex { get; set; }
        public string Header { get; set; }
        public string TypeParam { get; set; }
        public string Style { get; set; }
        public string SourceValue { get; set; }
        public string SourceLink { get; set; }
    }
}
