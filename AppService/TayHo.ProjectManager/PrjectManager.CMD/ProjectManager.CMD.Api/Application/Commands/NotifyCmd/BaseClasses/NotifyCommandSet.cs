namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NotifyCommandSet : BaseCommandClasses
    {
        public int? Type { get; set; }
        public string Category { get; set; }
        public string Message { get; set; }
        public string Link { get; set; }
        public int? TemplateId { get; set; }
        public string Title { get; set; }
        public string Sub { get; set; }
        public string BodyContent { get; set; }
    }
}
