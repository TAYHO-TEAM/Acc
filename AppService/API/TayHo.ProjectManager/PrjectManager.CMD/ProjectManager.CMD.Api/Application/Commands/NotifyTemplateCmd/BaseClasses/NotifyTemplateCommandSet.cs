using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NotifyTemplateCommandSet : BaseCommandClasses
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

    }
}
