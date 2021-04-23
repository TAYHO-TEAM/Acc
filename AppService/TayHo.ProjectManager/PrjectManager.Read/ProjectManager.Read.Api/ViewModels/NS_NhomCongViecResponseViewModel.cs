using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_NhomCongViecResponseViewModel : BaseResponseAccountInfoViewModel
    { 
        public int? HangMucId { get; set; }
        public int? LoaiCongViecId { get; set; }
        public int? GoiThauId { get; set; }
        public int? NhomChiPhiId { get; set; }
        public int? ProjectId { get; set; }
        public string TenNhomCongViec { get; set; }
        public string DienGiai { get; set; }
        public int? SortIndex { get; set; }
    }

    public class NS_NhomCongViec_NhomCongViecDetailResponseViewModel : NS_NhomCongViecResponseViewModel
    {
        public int? NhomCongViecDetailId { get; set; }
        public decimal? GiaTri { get; set; }
        public int? GiaiDoanId { get; set; }
    }
}
