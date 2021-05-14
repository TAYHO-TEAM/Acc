using Acc.Read.Api.ViewModels.BaseClasses;

namespace Acc.Read.Api.ViewModels
{
    public class PermistionsResponseViewModel : BaseResponseViewModel
    {
        public byte? Type { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
    }
}
