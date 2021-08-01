using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class MaintenancerInfo : DOBase
    {
       public int? MaintenanceSupplierInfoId { get;set;}
	public string Code { get;set;}
			public string Barcode { get;set;}
			public string FullName { get;set;}
			public string Phone { get;set;}
			public string Email { get;set;}
			public byte? Sex { get;set;}
			public string IDCard { get;set;}
			public int? Type { get;set;}
			public int? NoAttachment { get;set;}
			
    }
}
