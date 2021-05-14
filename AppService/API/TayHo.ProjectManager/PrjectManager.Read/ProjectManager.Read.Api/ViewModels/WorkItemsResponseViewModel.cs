using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class WorkItemsResponseViewModel : BaseResponseChilCountViewModel
    {
        public string Code { get; set; }
        public string BarCode { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? level { get; set; }
        public int? ProjectId { get; set; }
    }
}
