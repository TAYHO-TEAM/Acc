using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class CustomFormAccountResponseViewModel : BaseResponseViewModel
    {
        public int? CustomFormId { get; set; }
        public int? AccountId { get; set; }
        public int? GroupId { get; set; }
    }
}
