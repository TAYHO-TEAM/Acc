using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NotifyConfigCommandSet: BaseCommandClasses
    {
        public int? Type { get;set;}
	public string Code { get;set;}
			public string JobName { get;set;}
			public string TableName { get;set;}
			public string QuerryCMD { get;set;}
			
    }
}
