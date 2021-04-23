using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_NhomCongViecDetailDTO : DTOChilCountBase
    {
        public int? NhomCongViecId { get; set; }
        public int? GiaiDoanId { get; set; }
        public decimal? GiaTri { get; set; }
        public int? SortIndex { get; set; }
    }
}
