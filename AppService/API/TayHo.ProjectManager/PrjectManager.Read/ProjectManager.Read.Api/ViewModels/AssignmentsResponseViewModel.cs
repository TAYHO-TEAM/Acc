using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class AssignmentsResponseViewModel : BaseResponseViewModel
    {
        public int AccountId { get; set; }
        public int RequestId { get; set; }
        public int RequestDetailId { get; set; }
    }
}
