using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_DuChiDTO: DTOAccountInfoBase
    {
        public int? ProjectId { get; set; }
        public int? NhomCongViecId { get; set; }
        public int? GoiThauId { get; set; }
        public DateTime? ThoiGianBaoCao { get; set; }
        public DateTime? ThoiGianDuChi { get; set; }
        public decimal? GiaTri { get; set; }
    }
}
