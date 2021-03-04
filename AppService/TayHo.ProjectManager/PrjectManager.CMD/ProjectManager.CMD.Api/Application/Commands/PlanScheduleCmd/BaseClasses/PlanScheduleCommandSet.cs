using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class PlanScheduleCommandSet: BaseCommandClasses
    {
        public int? PlanMasterId { get;set;}
	public int? PlanJobId { get;set;}
			public string Title { get;set;}
			public string Note { get;set;}
			public DateTime? Remind { get;set;}
			public int? Repead { get;set;}
			public string RepeadType { get;set;}
			public DateTime? StartDate { get;set;}
			public DateTime? EndDate { get;set;}
			public int? ModifyTimes { get;set;}
			
    }
}
