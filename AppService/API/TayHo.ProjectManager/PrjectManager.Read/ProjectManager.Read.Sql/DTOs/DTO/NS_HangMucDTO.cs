using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_HangMucDTO: DTOAccountInfoBase
    {
        public int? ParentId { get; set; }
        public string TenHangMuc { get; set; }
        public string KyHieu { get; set; }
        public int? ProjectId { get; set; }
    }
    
    public class NS_HangMuc_HangMucDetailDTO: NS_HangMucDTO
    {
        public int? HangMucDetailId { get; set; }
        public decimal? GiaTri { get; set; }
        public int? GiaiDoanId { get; set; }
    }
}
