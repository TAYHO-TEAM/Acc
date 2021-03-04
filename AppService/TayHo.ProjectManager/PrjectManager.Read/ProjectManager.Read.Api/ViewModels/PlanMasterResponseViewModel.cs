using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class PlanMasterResponseViewModel : BaseResponseViewModel
    {
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
    }

    public class PlanMasterAccountResponseViewModel : BaseResponseAccountInfoViewModel
    {
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
    }
    public class PlanMasterAccountPermitResponseViewModel : BaseResponseAccountInfoPermitViewModel
    {
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
    }
}
