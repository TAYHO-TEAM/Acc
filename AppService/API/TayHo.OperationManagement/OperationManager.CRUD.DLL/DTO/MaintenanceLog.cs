using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class MaintenanceLog : DOBase
    {
       public string Code { get;set;}
	public string Barcode { get;set;}
			public int? Priority { get;set;}
			public int? ConstructionItemsId { get;set;}
			public int? MaintenancerInfoId { get;set;}
			public int? MaintenanceSupplierInfoId { get;set;}
			public int? MaintenanceScheduleId { get;set;}
			public string MaintaincerName { get;set;}
			public string MaintaincerPhone { get;set;}
			public string Note { get;set;}
			public string Result { get;set;}
			public byte? ResultType { get;set;}
			public DateTime? CurrentTimes { get;set;}
			public int? Times { get;set;}
			public DateTime? StartTime { get;set;}
			public DateTime? EndTime { get;set;}
			public int? Duration { get;set;}
			public string DurationUnit { get;set;}
			public byte? DurationUnitType { get;set;}
			public int? Type { get;set;}
			public int? NoAttachment { get;set;}
			
    }
}
