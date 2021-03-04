using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_NghiemThuDTO : DTOAccountInfoBase
    {
        public int? CongViecDetailId { get; set; }
        public int? GoiThauId { get; set; }
        public int? Dot { get; set; }
        public double? KhoiLuong { get; set; }
    }

    public class NS_NghiemThuDetailDTO : NS_NghiemThuDTO
    {
        public int? NhomCongViecId { get; set; }
        public string TenNhomCongViec { get; set; }
        public int? HangMucId { get; set; }
        public string TenHangMuc { get; set; } 
        public string DonViTinh { get; set; } 
        public decimal? DonGia { get; set; }
    }
}
