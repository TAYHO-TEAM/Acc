using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class PlanAccountCommandSet: BaseCommandClasses
    {
        public int? AccountId { get;set;}
	public int? GroupId { get;set;}
			public int? PermistionId { get;set;}
			public int? OwnerById { get;set;}
			public string OwnerTable { get;set;}
			
    }
}
