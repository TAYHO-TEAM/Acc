using System;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupsCommandSet : BaseCommandClasses
    {
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public byte Type { get; set; }
    }
}