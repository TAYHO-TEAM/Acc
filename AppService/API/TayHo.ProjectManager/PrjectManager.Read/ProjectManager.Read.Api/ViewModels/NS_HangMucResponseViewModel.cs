using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_HangMucResponseViewModel : BaseResponseAccountInfoViewModel
    {
        public int? ParentId { get; set; }
        public string TenHangMuc { get; set; }
        public string KyHieu { get; set; }
        public int? ProjectId { get; set; }
    }
    public class NS_HangMuc_HangMucDetailResponseViewModel : NS_HangMucResponseViewModel
    {
        public int? HangMucDetailId { get; set; }
        public decimal? GiaTri { get; set; }
        public int? GiaiDoanId { get; set; } 
    }
}
