using Acc.Read.Api.ViewModels.BaseClasses;

namespace Acc.Read.Api.ViewModels
{
    public class GroupFunctionPermistionResponseViewModel : BaseResponseViewModel
    {
        public int? GroupId { get; set; }
        public int? FunctionId { get; set; }
        public int? PermistionId { get; set; }
    }
}
