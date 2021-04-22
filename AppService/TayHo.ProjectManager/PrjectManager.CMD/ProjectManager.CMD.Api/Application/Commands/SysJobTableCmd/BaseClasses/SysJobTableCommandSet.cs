using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class SysJobTableCommandSet: BaseCommandClasses
    {
        public int? SysJobId { get;set;}
	public int? No { get;set;}
			public string Name { get;set;}
			public bool? IsHeader { get;set;}
			public string HeaderColor { get;set;}
			public string HeaderBackGroundColor { get;set;}
			public int? Border { get;set;}
			public string Color { get;set;}
			public string BackGroundColor { get;set;}
			public int? BeginRow { get;set;}
			public int? BeginCol { get;set;}
			public int? Priority { get;set;}
			public string Style { get;set;}
			
    }
}
