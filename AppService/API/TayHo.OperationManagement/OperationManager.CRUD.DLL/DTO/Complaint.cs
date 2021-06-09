using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class Complaint : DOBase
    {
       public string Code { get;set;}
	public string Barcode { get;set;}
			public int? ComplaintTypeId { get;set;}
			public int? CustomerId { get;set;}
			public int? ConstructionItemsId { get;set;}
			public int? RealEstateId { get;set;}
			public string FullName { get;set;}
			public string Phone { get;set;}
			public string Note { get;set;}
			public int? NoAttachment { get;set;}
			
    }
}
