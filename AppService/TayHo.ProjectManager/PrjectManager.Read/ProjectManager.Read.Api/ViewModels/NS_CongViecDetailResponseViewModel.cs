using ProjectManager.Read.Api.ViewModels.BaseClasses;
using ProjectManager.Read.Sql.DTOs.DTO;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_CongViecDetailResponseViewModel : BaseResponseAccountInfoViewModel
    {
        public int? CongViecId { get; set; }
        public int? GiaiDoanId { get; set; }
        public decimal? DonGia { get; set; }
        public int? KhoiLuong { get; set; }
        public int? ReasonId { get; set; }
    }

    public class NS_CongViecDetail_GoiThau_GiaiDoanResponseViewModel : NS_CongViecDetailResponseViewModel
    {
        public string TenNhomCongViec { get; set; }
        public int? GoiThauId { get; set; }
        public string TenCongViec { get; set; }
        public string DonViTinh { get; set; }
        public string Nhom { get; set; }
        public string DienGiai { get; set; }
        public int? LuyKe { get; set; }
    }
}
