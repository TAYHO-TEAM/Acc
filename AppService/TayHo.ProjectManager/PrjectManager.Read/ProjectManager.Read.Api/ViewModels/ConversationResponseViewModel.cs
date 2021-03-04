using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class ConversationResponseViewModel : BaseResponseViewModel
    {
        public string OwnerTable { get; set; }
        public int? TopicId { get; set; }
        public int? ParentId { get; set; }
        public string Content { get; set; }
    }
}
