using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DTOs
{
    public class NotifyAccountDetail
    {

        public int? NId { get; set; }
        public int? NType { get; set; }
        public string NCategory { get; set; }
        public string NMessage { get; set; }
        public string NLink { get; set; }
        public int? NTemplateId { get; set; }
        public string NTitle { get; set; }
        public string NSub { get; set; }
        public string NBodyContent { get; set; }
        public bool? NIsDelete { get; set; }
        public bool? NIsActive { get; set; }
        public bool? NIsVisible { get; set; }
        public bool? NIsModify { get; set; }
        public int? NCreateBy { get; set; }
        public DateTime? NCreateDateUTC { get; set; }
        public DateTime? NCreateDate { get; set; }
        public int? NModifyBy { get; set; }
        public DateTime? NUpdateDateUTC { get; set; }
        public DateTime? NUpdateDate { get; set; }
        public byte? NStatus { get; set; }
        [Key]
        public int? NAId { get; set; }
        public int? NAAccountId { get; set; }
        public int? NAGroupId { get; set; }
        public int? NANotifyId { get; set; }
        public DateTime? NAPushTime { get; set; }
        public bool? NAIsDelete { get; set; }
        public bool? NAIsActive { get; set; }
        public bool? NAIsVisible { get; set; }
        public bool? NAIsModify { get; set; }
        public int? NACreateBy { get; set; }
        public DateTime? NACreateDateUTC { get; set; }
        public DateTime? NACreateDate { get; set; }
        public int? NAModifyBy { get; set; }
        public DateTime? NAUpdateDateUTC { get; set; }
        public DateTime? NAUpdateDate { get; set; }
        public byte? NAStatus { get; set; }
        public int? CreateBy{get; set;}
        public bool? IsDelete { get; set; }
    }
}
