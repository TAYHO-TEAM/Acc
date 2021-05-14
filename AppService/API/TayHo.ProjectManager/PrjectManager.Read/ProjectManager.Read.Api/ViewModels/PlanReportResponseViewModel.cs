using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class PlanReportResponseViewModel : BaseResponseViewModel
    {
        public int? PlanMasterId { get; set; }
        public int? PlanJobId { get; set; }
        public string Content { get; set; }
        public string Unit { get; set; }
        public int? Amount { get; set; }
    }
}
