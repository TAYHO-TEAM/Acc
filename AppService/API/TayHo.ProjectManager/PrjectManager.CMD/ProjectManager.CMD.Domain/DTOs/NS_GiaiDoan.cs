using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DTOs
{
    public class NS_GiaiDoan 
    {
        [Key]
        public int Id { get; set; }
        public string TenGiaiDoan { get; set; }
        public string DienGiai { get; set; }
        public int? ProjectId { get; set; }
        public int? GroupId { get; set; }
        public string CapDo { get; set; }
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
