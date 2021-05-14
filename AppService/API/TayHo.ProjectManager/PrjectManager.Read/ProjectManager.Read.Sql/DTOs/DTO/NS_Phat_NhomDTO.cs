using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_Phat_NhomDTO : DTOAccountInfoBase
    {
        public string TenNhomPhat { get; set; }
        public string DienGiai { get; set; }
        public int? SortIndex { get; set; }
    }
}
