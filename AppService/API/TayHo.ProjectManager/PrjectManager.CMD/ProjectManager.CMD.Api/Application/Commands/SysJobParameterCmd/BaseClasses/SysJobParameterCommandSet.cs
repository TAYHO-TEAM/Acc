using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class SysJobParameterCommandSet: BaseCommandClasses
    {
        public string SysJobId { get;set;}
	public string Name { get;set;}
			public string DisplayName { get;set;}
			public string DataTypeSQL { get;set;}
			public string DataTypeC { get;set;}
			public string DefaultValue { get;set;}
			
    }
}
