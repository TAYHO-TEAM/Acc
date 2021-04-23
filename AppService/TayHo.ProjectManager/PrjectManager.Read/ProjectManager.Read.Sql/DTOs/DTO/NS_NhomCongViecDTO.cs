using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_NhomCongViecDTO : DTOAccountInfoBase
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
    public class NS_NhomCongViec_NhomCongViecDetailDTO : NS_NhomCongViecDTO
    {
        public int? NhomCongViecDetailId { get; set; }
        public decimal? GiaTri { get; set; }
        public int? GiaiDoanId { get; set; }
    }
}
