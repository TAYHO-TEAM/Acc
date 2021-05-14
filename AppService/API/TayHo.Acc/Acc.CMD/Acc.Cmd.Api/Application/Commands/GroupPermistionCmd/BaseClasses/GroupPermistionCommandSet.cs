using System;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupPermistionCommandSet : BaseCommandClasses
    {
        public int PermistionId { get; set; }
        public int GroupId { get; set; }
    }
}