using Acc.Read.Api.ViewModels.BaseClasses;

namespace Acc.Read.Api.ViewModels
{
    public class GroupPermistionResponseViewModel : BaseResponseViewModel
    {
        public int? PermistionId { get; set; }
        public int? GroupId { get; set; }
    }
}
