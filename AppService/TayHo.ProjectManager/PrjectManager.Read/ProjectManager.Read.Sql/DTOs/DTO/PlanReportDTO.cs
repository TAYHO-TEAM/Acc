using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class PlanReportDTO : DTOBase
    {
        public int? PlanMasterId { get; set; }
        public int? PlanJobId { get; set; }
        public string Content { get; set; }
        public string Unit { get; set; }
        public int? Amount { get; set; }
    }
}
