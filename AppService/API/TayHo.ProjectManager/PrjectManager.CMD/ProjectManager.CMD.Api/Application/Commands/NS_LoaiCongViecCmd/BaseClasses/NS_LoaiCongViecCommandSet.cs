namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_LoaiCongViecCommandSet : BaseCommandClasses
    {
        public string TenLoaiCongViec { get; set; }
        public string DienGiai { get; set; }
        public string KyHieu { get; set; }
        public int? ProjectId { get; set; }
        public int? SortIndex { get; set; }
    }
}