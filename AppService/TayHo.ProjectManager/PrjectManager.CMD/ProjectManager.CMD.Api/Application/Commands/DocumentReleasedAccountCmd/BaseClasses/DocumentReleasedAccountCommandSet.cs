namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DocumentReleasedAccountCommandSet : BaseCommandClasses
    {
        public int? AccountId { get; set; }
        public int? DocumentReleasedId { get; set; }
        public int? GroupId { get; set; }
    }
    public class DocumentReleasedAccountsCommandSet : BaseCommandClasses
    {
        public int[] AccountId { get; set; }
        public int[] GroupId { get; set; }
        public int? DocumentReleasedId { get; set; }
    }
}