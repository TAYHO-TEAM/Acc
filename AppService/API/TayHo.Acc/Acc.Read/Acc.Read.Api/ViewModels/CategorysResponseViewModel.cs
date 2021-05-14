using Acc.Read.Api.ViewModels.BaseClasses;

namespace Acc.Read.Api.ViewModels
{
    public class CategorysResponseViewModel : BaseResponseViewModel
    {
        public string Title { get; set; }
        public string Descriptions { get; set; }
    }
}
