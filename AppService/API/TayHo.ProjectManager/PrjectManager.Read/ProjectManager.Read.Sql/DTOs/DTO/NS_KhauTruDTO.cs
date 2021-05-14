using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_KhauTruDTO : DTOAccountInfoBase
    {
        public int? GoiThauId { get; set; }
        public int? ProjectId { get; set; }
        public string NoiDung { get; set; }
        public string DienGiai { get; set; }
        public decimal? GiaTri { get; set; }
        public decimal? GiaTriCon { get; set; }
    }
}
