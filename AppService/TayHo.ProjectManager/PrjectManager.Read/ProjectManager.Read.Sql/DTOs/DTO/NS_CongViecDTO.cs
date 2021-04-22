using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_CongViecDTO : DTOAccountInfoBase
    {
        public int? NhomCongViecId { get; set; }       
        public string Nhom { get; set; }
        public string TenCongViec { get; set; }
        public string DienGiai { get; set; }
        public string DonViTinh { get; set; }
    }



    public class NS_CongViec_CongViecDetailDTO : NS_CongViecDTO
    {
        public int? CongViecDetailId { get; set; }
        public int? GiaiDoanId { get; set; }
        public int? ReasonId { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? KhoiLuong { get; set; }
    }
}
