using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_CongViecResponseViewModel : BaseResponseAccountInfoViewModel
    {
        public int? NhomCongViecId { get; set; }
        public string Nhom { get; set; }
        public string TenCongViec { get; set; }
        public string DienGiai { get; set; }
        public string DonViTinh { get; set; }
    }

    public class NS_CongViec_CongViecDetailResponseViewModel : NS_CongViecResponseViewModel
    {
        public int? CongViecDetailId { get; set; }
        public int? GiaiDoanId { get; set; }
        public int? ReasonId { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? KhoiLuong { get; set; }
    }
}
