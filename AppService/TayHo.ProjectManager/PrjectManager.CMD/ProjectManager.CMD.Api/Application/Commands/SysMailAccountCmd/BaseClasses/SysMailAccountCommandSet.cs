using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class SysMailAccountCommandSet: BaseCommandClasses
    {
        public int? SysAutoSendMailId { get;set;}
	public string Email { get;set;}
			public int? Type { get;set;}
			
    }
}
