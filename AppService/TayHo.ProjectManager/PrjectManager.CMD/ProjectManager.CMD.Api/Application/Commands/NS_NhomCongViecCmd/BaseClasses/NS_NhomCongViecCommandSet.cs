namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_NhomCongViecCommandSet : BaseCommandClasses
    {
        public int? HangMucId { get; set; }
        public int? LoaiCongViecId { get; set; }
        public int? GoiThauId { get; set; }
        public int? NhomChiPhiId { get; set; }
        public int? ProjectId { get; set; }
        public string TenNhomCongViec { get; set; }
        public string DienGiai { get; set; }
        public int? SortIndex { get; set; }
    }
}