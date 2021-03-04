using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class PlanProjectResponseViewModel : BaseResponseViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Priority { get; set; }
        public int? ProjectId { get; set; }
    }
}
