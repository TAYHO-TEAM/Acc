using System;

namespace Acc.Cmd.Api.Application.Commands
{
    public class StagesCommandSet : BaseCommandClasses
    {
        public int ActionId { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int CategoryId { get; set; }
        public int Level { get; set; }
    }
}