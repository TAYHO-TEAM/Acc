using Acc.Read.Api.ViewModels.BaseClasses;

namespace Acc.Read.Api.ViewModels
{
    public class GroupAccountResponseViewModel : BaseResponseViewModel
    {
        public int? AccountId { get; set; }
        public int? GroupId { get; set; }
    }
}
