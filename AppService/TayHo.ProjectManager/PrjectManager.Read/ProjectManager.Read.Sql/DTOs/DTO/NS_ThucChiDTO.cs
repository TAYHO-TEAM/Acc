using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_ThucChiDTO: DTOAccountInfoBase
    {
        public int? NhomCongViecId { get; set; }
        public int? GoiThauId { get; set; }
        public string ThangBaoCao { get; set; }
        public string ThangDuChi { get; set; }
        public decimal? GiaTri { get; set; }
    }
}
