using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class Project : DOBase
    {
       public string Code { get;set;}
	public string BarCode { get;set;}
			public string Title { get;set;}
			public string Descriptions { get;set;}
			public int? ParentId { get;set;}
			public int? NodeLevel { get;set;}
			public int? OldId { get;set;}
			
    }
}
