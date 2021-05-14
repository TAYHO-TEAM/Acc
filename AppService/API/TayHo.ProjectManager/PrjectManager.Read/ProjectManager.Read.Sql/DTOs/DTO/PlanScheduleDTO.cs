using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class PlanScheduleDTO : DTOBase
    {
        public int? PlanMasterId { get; set; }
        public int? PlanJobId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public DateTime? Remind { get; set; }
        public int? Repead { get; set; }
        public string RepeadType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ModifyTimes { get; set; }
    }
}
