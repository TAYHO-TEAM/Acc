using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_CongViecDetailDTO : DTOAccountInfoBase
    {
        public int? CongViecId { get; set; }
        public int? GiaiDoanId { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? KhoiLuong { get; set; }
        public int? ReasonId { get; set; }
    }
    public class NS_CongViecDetail_GoiThau_GiaiDoanDTO : NS_CongViecDetailDTO
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
