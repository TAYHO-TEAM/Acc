using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{

    public class PlanMasterDTO : DTOBase
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
    public class PlanMasterAccountDTO : DTOAccountInfoBase
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

    public class PlanMasterAccountPermitDTO : DTOAccountInfoPermitBase
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
