using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ConversationCommandSet : BaseCommandClasses
    {
        public string OwnerTable { get; set; }
        public int? TopicId { get; set; }
        public int? ParentId { get; set; }
        public string Content { get; set; }
        public byte? NoAttachment { get; set; }

    }
}
