using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DTOs
{
    public class PlanMasterAccount
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
        public string Code { get; set; }
        public int? ParentId { get; set; }
        public string PlanProjectId { get; set; }
        public string Title { get; set; }
        public int? TimeLine { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Unit { get; set; }
        public int? Amount { get; set; }
        public string ReportPeriodicalType { get; set; }
        public int? ReportPeriodical { get; set; }
        public int? ReportFrequency { get; set; }
        public int? Priority { get; set; }
        public byte? ImportantLevel { get; set; }
        public byte? NoAttachment { get; set; }
        public bool? PMIsDelete { get; set; }
        public bool? PMIsActive { get; set; }
        public bool? PMIsVisible { get; set; }
        public bool? PMIsModify { get; set; }
        public int? PMCreateBy { get; set; }
        public DateTime? PMCreateDateUTC { get; set; }
        public DateTime? PMCreateDate { get; set; }
        public int? PMModifyBy { get; set; }
        public DateTime? PMUpdateDateUTC { get; set; }
        public DateTime? PMUpdateDate { get; set; }
        public byte? PMStatus { get; set; }
        public int? CreateBy{get; set;}
        public bool? IsDelete { get; set; }
    }
}
