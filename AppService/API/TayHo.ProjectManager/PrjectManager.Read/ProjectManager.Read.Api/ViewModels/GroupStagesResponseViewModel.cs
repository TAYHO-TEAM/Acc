using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class GroupStagesResponseViewModel : BaseResponseViewModel
    {
        public int? GroupId { get; set; }
        public int? StageId { get; set; }
    }
}
