using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_LoaiCongViecResponseViewModel : BaseResponseChilCountViewModel
    {
        public string TenLoaiCongViec { get; set; }
        public string DienGiai { get; set; }
        public string KyHieu { get; set; }
        public int? ProjectId { get; set; }
        public int? SortIndex { get; set; }
    }
}
