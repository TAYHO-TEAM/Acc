using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class CustomTableResponseViewModel : BaseResponseViewModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int? NoColum { get; set; }
        public int? NoRown { get; set; }
        public string Style { get; set; }
        public int? Priority { get; set; }
    }
}
