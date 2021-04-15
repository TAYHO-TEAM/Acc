using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class SysJobColumCommandSet: BaseCommandClasses
    {
        public int? NoCol { get;set;}
	public int? SysJobTableId { get;set;}
			public string Style { get;set;}
			public string Formulas { get;set;}
			public string Functions { get;set;}
			
    }
}
