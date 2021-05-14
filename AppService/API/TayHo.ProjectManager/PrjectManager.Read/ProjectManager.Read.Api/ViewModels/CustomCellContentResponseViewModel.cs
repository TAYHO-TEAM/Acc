using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class CustomCellContentResponseViewModel : BaseResponseViewModel
    {
        public int? CustomFormContentId { get; set; }
        public int? CustomColumId { get; set; }
        public string Contents { get; set; }
        public int? NoRown { get; set; }
    }
}
