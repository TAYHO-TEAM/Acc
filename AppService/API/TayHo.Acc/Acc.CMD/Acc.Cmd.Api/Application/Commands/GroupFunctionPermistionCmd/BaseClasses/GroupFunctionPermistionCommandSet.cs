using System;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupFunctionPermistionCommandSet : BaseCommandClasses
    {
        public int GroupId { get; set; }
        public int FunctionId { get; set; }
        public int PermistionId { get; set; }
    }
}