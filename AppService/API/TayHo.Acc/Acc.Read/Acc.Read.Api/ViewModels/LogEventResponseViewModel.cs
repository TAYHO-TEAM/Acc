using Acc.Read.Api.ViewModels.BaseClasses;

namespace Acc.Read.Api.ViewModels
{
    public class LogEventResponseViewModel : BaseResponseViewModel
    {
        public int? UserId { get; set; }
        public string Event { get; set; }
        public string Action { get; set; }
        public int? OwnerById { get; set; }
        public string OwnerByTable { get; set; }
        public int? FunctionId { get; set; }
        public string Message { get; set; }
    }
}
