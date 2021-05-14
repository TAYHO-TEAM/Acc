using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class PlanProjectCommandSet: BaseCommandClasses
    {
        public string Title { get;set;}
	public string Description { get;set;}
			public int? Priority { get;set;}
			public int? ProjectId { get;set;}
			
    }
}
