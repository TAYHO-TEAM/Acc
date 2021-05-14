using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_ThucChiResponseViewModel : BaseResponseAccountInfoViewModel
    {
        public int? NhomCongViecId { get; set; }
        public int? GoiThauId { get; set; }
        public string ThangBaoCao { get; set; }
        public string ThangDuChi { get; set; }
        public decimal? GiaTri { get; set; }
    }
}
