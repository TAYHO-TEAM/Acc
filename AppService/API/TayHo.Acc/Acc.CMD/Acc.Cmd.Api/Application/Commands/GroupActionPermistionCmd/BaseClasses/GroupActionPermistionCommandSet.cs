using System;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupActionPermistionCommandSet : BaseCommandClasses
    {
        public int PermistionId { get; set; }
        public int GroupId { get; set; }
        public int ActionId { get; set; }
    }
}