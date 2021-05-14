using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Utilities
{
    public class CongViecOBJ
    {
        public int? nhomCongViecId { get; set; }
        public string nhom { get; set; }
        public string tenCongViec { get; set; }
        public string dienGiai { get; set; }
        public string dvt { get; set; }
        public decimal? donGia { get; set; }
        public decimal? khoiLuong { get; set; }
        public int? giaiDoanId { get; set; }
    }

    public class CongViecsOBJ
    {
        public string congViecOBJs { get; set; }
        public string token { get; set; }
    }

    public class CongViecDetailModel
    {
        public int? CongViecId { get; set; }
        public int? GiaiDoanId { get; set; }
        public int? ReasonId { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? KhoiLuong { get; set; }
    } 

    public class CongViecModel
    {
        public int? NhomCongViecId { get; set; }
        public string Nhom { get; set; }
        public string TenCongViec { get; set; }
        public string DienGiai { get; set; }
        public string DonViTinh { get; set; }
    } 
}