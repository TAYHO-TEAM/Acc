using System;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupStepProcessPermistionCommandSet : BaseCommandClasses
    {
        public int? GroupId { get; set; }
        public int? StepProcessId { get; set; }
        public int? Permistion { get; set; }
    }
}