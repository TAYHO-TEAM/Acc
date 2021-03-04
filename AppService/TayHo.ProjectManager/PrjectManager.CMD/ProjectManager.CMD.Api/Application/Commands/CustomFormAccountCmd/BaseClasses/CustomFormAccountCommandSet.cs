using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CustomFormAccountCommandSet: BaseCommandClasses
    {
        public int? CustomFormId { get;set;}
	public int? AccountId { get;set;}
			public int? GroupId { get;set;}
			
    }
}
