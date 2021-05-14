using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class PlanAccountResponseViewModel : BaseResponseViewModel
    {
        public int? AccountId { get; set; }
        public int? GroupId { get; set; }
        public int? PermistionId { get; set; }
        public int? OwnerById { get; set; }
        public string OwnerTable { get; set; }
    }
}
