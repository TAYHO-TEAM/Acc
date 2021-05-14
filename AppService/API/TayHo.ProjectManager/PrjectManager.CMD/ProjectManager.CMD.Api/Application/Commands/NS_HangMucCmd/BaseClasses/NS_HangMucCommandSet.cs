namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_HangMucCommandSet : BaseCommandClasses
    {
        public int? ParentId { get; set; }
        public string TenHangMuc { get; set; }
        public string KyHieu { get; set; }
        public int? ProjectId { get; set; }
    }
}