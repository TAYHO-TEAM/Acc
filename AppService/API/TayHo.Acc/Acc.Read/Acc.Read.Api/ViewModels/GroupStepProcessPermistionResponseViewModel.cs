using Acc.Read.Api.ViewModels.BaseClasses;

namespace Acc.Read.Api.ViewModels
{
    public class GroupStepProcessPermistionResponseViewModel : BaseResponseViewModel
    {
        public int? GroupId { get; set; }
        public int? StepProcessId { get; set; }
        public int? Permistion { get; set; }
    }
}
