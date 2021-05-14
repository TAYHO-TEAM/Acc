using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class ProblemCategoryResponseViewModel : BaseResponseViewModel
    {
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public byte? Priotity { get; set; }
    }
}
