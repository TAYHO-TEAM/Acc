using System;

namespace Acc.Cmd.Api.Application.Commands
{
    public class RelationTableCommandSet : BaseCommandClasses
    {
        public string PrimaryTable { get; set; }
        public string PrimaryKey { get; set; }
        public string ForeignTable { get; set; }
        public string ForeignKey { get; set; }
    }
}