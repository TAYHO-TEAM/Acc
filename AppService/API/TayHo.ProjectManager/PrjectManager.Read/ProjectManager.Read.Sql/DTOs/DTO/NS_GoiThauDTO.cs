using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_GoiThauDTO: DTOAccountInfoBase
    {
        public int? ParentId { get; set; } 
        public int? ProjectId { get; set; }
        public string SoHopDong { get; set; }
        public int? ContractorInfoId { get; set; }
        public DateTime? NgayKy { get; set; }
        public string DienGiai { get; set; }
        public short? ThoiGianBaoHanh { get; set; }
        public short? ThoiGianGiuBaoHanh { get; set; }
        public double? TyLeTamUng { get; set; }
        public double? TyLeGiuLai { get; set; }
        public double? TyLeThanhToanToiDa { get; set; }
        public decimal? GiaTri { get; set; }
    }
}
