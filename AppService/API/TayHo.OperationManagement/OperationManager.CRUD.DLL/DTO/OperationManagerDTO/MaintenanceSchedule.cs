using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class MaintenanceSchedule : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? ConstructionItemsId { get; set; }
        public int? MaintenanceSupplierInfoId { get; set; }
        public int? MaintenancerInfoId { get; set; }
        public string Title { get; set; }
        public int? Cycle { get; set; }
        public int? Priority { get; set; }
        public bool? IsRemind { get; set; }
        public string RemindBy { get; set; }
        public DateTime? LastTimes { get; set; }
        public DateTime? NextTimes { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Times { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Type { get; set; }
        public int? NoAttachment { get; set; }

    }
}
