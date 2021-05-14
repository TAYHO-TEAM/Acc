namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_GiaiDoanCommandSet : BaseCommandClasses
    {
        public string TenGiaiDoan { get; set; }
        public string DienGiai { get; set; }
        public int? ProjectId { get; set; }
        public int? GroupId { get; set; }
        public string CapDo { get; set; }
        public int? SortIndex { get; set; }
    }
}