namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ResponseRegistReplyCommandSet : BaseCommandClasses
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ReplyAccountId { get; set; }
        public int? ResponseRegitId { get; set; }
        public byte? NoAttachment { get; set; }
    }
}