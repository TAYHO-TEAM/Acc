using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_NhomCongViecDetailResponseViewModel : BaseResponseViewModel
    {
        public int? NhomCongViecId { get; set; }
        public int? GiaiDoanId { get; set; }
        public decimal? GiaTri { get; set; }
        public int? SortIndex { get; set; }
    }
}
