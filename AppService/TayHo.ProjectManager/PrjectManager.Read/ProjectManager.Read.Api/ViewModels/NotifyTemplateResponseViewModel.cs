using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NotifyTemplateResponseViewModel : BaseResponseViewModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
