using Acc.Read.Api.ViewModels.BaseClasses;

namespace Acc.Read.Api.ViewModels
{
    public class GroupActionPermistionResponseViewModel : BaseResponseViewModel
    {
        public int? ActionId { get; set; }
        public int? PermistionId { get; set; }
        public int? GroupId { get; set; }
    }
}
