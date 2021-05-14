using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class ActionsResponseViewModel //: BaseResponseViewModel
    {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int? CategoryId { get; set; }
        public int? Level { get; set; }
    }
}
