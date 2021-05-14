namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DocumentTypeCommandSet : BaseCommandClasses
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public int? OperationProcessId { get; set; }
    }
}