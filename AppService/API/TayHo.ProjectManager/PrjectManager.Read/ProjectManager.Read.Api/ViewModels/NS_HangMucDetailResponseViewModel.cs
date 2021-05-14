using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_HangMucDetailResponseViewModel : BaseResponseViewModel
    {
        public int? HangMucId { get; set; }
        public int? ProjectId { get; set; }
        public int? GiaiDoanId { get; set; }
        public decimal? GiaTri { get; set; }
    }
}
