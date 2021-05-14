using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class StepsProcessResponseViewModel : BaseResponseViewModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public byte? Priority { get; set; }
        public int? ParentId { get; set; }
        public int? Level { get; set; }
        public int? PreviousId { get; set; }
        public int? NextId { get; set; }
        public int? OperationProcessId { get; set; }
    }
}
