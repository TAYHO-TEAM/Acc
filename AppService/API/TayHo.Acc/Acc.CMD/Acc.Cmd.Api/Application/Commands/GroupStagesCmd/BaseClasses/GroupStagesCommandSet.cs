using System;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupStagesCommandSet : BaseCommandClasses
    {
        public int StagesId { get; set; }
        public int GroupId { get; set; }
    }
}