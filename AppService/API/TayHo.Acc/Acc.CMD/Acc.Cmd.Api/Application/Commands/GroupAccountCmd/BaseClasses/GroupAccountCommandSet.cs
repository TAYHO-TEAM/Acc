using System;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupAccountCommandSet : BaseCommandClasses
    {
        public int AccountId { get; set; }
        public int GroupId { get; set; }
    }
}