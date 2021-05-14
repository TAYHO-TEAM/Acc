namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DocumentReleasedLogCommandSet : BaseCommandClasses
    {
        public int? AccountId { get; set; }
        public int? DocumentReleasedId { get; set; }
        public string Note { get; set; }
    }
}