namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ReplyCommandSet : BaseCommandClasses
    {
        public int RequestDetailId { get; set; }
        public string Title { get; set; }
        public byte NoAttachment { get; set; }
        public string Content { get; set; }
    }
}