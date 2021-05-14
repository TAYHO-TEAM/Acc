using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class TemplateMailCommandSet: BaseCommandClasses
    {
        public string Title { get;set;}
	public string BodyContent { get;set;}
			public bool? IsBodyHtml { get;set;}
			
    }
}
