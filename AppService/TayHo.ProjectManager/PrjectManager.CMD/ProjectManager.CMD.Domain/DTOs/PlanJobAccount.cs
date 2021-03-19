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
        public int? Id { get; set; }
        public int? PlanMasterId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int? Amount { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ModifyTimes { get; set; }
        public int? Priority { get; set; }
        public byte? ImportantLevel { get; set; }
        public bool? IsDone { get; set; }
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
