using Acc.Read.Api.ViewModels.BaseClasses;

namespace Acc.Read.Api.ViewModels
{
    public class GroupActionResponseViewModel : BaseResponseViewModel
    {
        public int? GroupId { get; set; }
        public int? ActionId { get; set; }
    }
}
