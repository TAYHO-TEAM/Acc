using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class DocumentReleasedAccountResponseViewModel : BaseResponseViewModel
    {
        public int? AccountId { get; set; }
        public int? DocumentReleasedId { get; set; }
        public int? GroupId { get; set; }
    }
    
}
