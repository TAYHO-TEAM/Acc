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
        public int? PMId { get; set; }
        public string PMCode { get; set; }
        public int? PMParentId { get; set; }
        public string PMPlanProjectId { get; set; }
        public string PMTitle { get; set; }
        public int? PMTimeLine { get; set; }
        public string PMDescription { get; set; }
        public string PMNote { get; set; }
        public DateTime? PMStartDate { get; set; }
        public DateTime? PMEndDate { get; set; }
        public string PMUnit { get; set; }
        public int? PMAmount { get; set; }
        public string PMReportPeriodicalType { get; set; }
        public int? PMReportPeriodical { get; set; }
        public int? PMReportFrequency { get; set; }
        public int? PMPriority { get; set; }
        public byte? PMImportantLevel { get; set; }
        public byte? PMNoAttachment { get; set; }
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
