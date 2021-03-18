using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DTOs
{
    public class PlanJobAccount
    {
        [Key]
        public int? PAId { get; set; }
        public int? PAAccountId { get; set; }
        public int? PAGroupId { get; set; }
        public int? PAPermistionId { get; set; }
        public int? PAOwnerById { get; set; }
        public string PAOwnerTable { get; set; }
        public bool? PAIsDelete { get; set; }
        public bool? PAIsActive { get; set; }
        public bool? PAIsVisible { get; set; }
        public bool? PAIsModify { get; set; }
        public int? PACreateBy { get; set; }
        public DateTime? PACreateDateUTC { get; set; }
        public DateTime? PACreateDate { get; set; }
        public int? PAModifyBy { get; set; }
        public DateTime? PAUpdateDateUTC { get; set; }
        public DateTime? PAUpdateDate { get; set; }
        public byte? PAStatus { get; set; }
        public int? PJId { get; set; }
        public int? PJPlanMasterId { get; set; }
        public int? PJParentId { get; set; }
        public string PJTitle { get; set; }
        public string PJDescription { get; set; }
        public string PJUnit { get; set; }
        public int? PJAmount { get; set; }
        public DateTime? PJStartDate { get; set; }
        public DateTime? PJEndDate { get; set; }
        public int? PJModifyTimes { get; set; }
        public int? PJPriority { get; set; }
        public byte? PJImportantLevel { get; set; }
        public bool? PJIsDone { get; set; }
        public bool? PJIsDelete { get; set; }
        public bool? PJIsActive { get; set; }
        public bool? PJIsVisible { get; set; }
        public bool? PJIsModify { get; set; }
        public int? PJCreateBy { get; set; }
        public DateTime? PJCreateDateUTC { get; set; }
        public DateTime? PJCreateDate { get; set; }
        public int? PJModifyBy { get; set; }
        public DateTime? PJUpdateDateUTC { get; set; }
        public DateTime? PJUpdateDate { get; set; }
        public byte? PJStatus { get; set; }
        public int? CreateBy{get; set;}
        public bool? IsDelete { get; set; }
    }
}
