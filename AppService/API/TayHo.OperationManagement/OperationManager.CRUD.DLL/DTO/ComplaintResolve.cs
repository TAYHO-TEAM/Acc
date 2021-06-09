using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class ComplaintResolve : DOBase
    {
       public string Code { get;set;}
	public string Barcode { get;set;}
			public int? ComplaintId { get;set;}
			public int? ParentId { get;set;}
			public string Resolver { get;set;}
			public string ResolverPhone { get;set;}
			public DateTime? StartDate { get;set;}
			public DateTime? EndDate { get;set;}
			public DateTime? Deadline { get;set;}
			public DateTime? ResolveDate { get;set;}
			public string Result { get;set;}
			public int? ResultType { get;set;}
			public string Note { get;set;}
			public int? NoAttachment { get;set;}
			
    }
}
