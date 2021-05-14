using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class ReplyResponseViewModel : BaseResponseViewModel
    {
        public int? RequestDetailId { get; set; }
        public string Title { get; set; }
        public byte? NoAttachment { get; set; }
        public string Content { get; set; }
    }
}
