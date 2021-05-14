using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_NghiemThuResponseViewModel : BaseResponseAccountInfoViewModel
    {
        public int? CongViecDetailId { get; set; }
        public int? GoiThauId { get; set; }
        public int? GiaiDoanId { get; set; }
        public int? Dot { get; set; }
        public double? KhoiLuong { get; set; }
    }


    public class NS_NghiemThuDetailViewModel : NS_NghiemThuResponseViewModel
    {
        public double? KhoiLuongLuyKe { get; set; }
        public double? KhoiLuongGiaoThau { get; set; }
        public int? NhomCongViecId { get; set; }
        public string TenNhomCongViec { get; set; }
        public int? HangMucId { get; set; }
        public string TenHangMuc { get; set; }
        public string DonViTinh { get; set; }
        public decimal? DonGia { get; set; }
    }
}
