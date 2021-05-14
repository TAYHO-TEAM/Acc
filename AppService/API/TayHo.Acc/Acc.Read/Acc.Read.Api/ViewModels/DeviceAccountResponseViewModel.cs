using Acc.Read.Api.ViewModels.BaseClasses;

namespace Acc.Read.Api.ViewModels
{
    public class DeviceAccountResponseViewModel : BaseResponseViewModel
    {
        public string Device { get; set; }
        public int? AccountId { get; set; }
        public string DeviceToken { get; set; }
        public string Browser { get; set; }
    }
}
