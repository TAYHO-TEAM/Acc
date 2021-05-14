using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Read.Sql.DTOs.BaseClasses
{
    public class SysDTOBase
    {
        public int Id { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsVisible { get; set; }
        public bool? IsModify { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDateUTC { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifyBy { get; set; }
        public DateTime? UpdateDateUTC { get; set; }
        public DateTime? UpdateDate { get; set; }
        public byte? Status { get; set; }
    }
}
