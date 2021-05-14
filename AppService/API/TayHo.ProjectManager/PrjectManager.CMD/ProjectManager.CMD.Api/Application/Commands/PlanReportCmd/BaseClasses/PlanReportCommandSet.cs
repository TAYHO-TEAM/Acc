using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class PlanReportCommandSet: BaseCommandClasses
    {
        public int? PlanMasterId { get;set;}
	public int? PlanJobId { get;set;}
			public string Content { get;set;}
			public string Unit { get;set;}
			public int? Amount { get;set;}
			
    }
}
