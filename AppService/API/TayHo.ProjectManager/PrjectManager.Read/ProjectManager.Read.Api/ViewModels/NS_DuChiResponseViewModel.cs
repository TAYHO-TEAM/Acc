using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_DuChiResponseViewModel : BaseResponseAccountInfoViewModel
    {
        public int? ProjectId { get; set; }
        public int? NhomCongViecId { get; set; }
        public int? GroupId { get; set; }
        public DateTime? ThoiGianBaoCao { get; set; }
        public DateTime? ThoiGianDuChi { get; set; }
        public decimal? GiaTri { get; set; }
    }
}
