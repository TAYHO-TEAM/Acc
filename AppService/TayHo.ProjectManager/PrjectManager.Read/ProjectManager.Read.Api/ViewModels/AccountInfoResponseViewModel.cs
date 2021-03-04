using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class AccountInfoResponseViewModel //: BaseResponseViewModel
    {
        public int? AccountId { get; set; }
        public string AccountName { get; set; }
        public string UserName { get; set; }
        public byte[]? AvatarImg { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Type { get; set; }
    }
}
