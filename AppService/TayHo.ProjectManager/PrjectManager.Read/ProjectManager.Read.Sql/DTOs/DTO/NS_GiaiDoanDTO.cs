using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_GiaiDoanDTO : DTOBase
    {
        public string TenGiaiDoan { get; set; }
        public string DienGiai { get; set; }
        public int? ProjectId { get; set; }
        public int? GroupId { get; set; }
        public string CapDo { get; set; }
        public int? SortIndex { get; set; }
    }
}
