using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_TamUngResponseViewModel : BaseResponseAccountInfoViewModel
    {
        public int? GoiThauId { get; set; }
        public int? ProjectId { get; set; }
        public string NoiDung { get; set; }
        public string DienGiai { get; set; }
        public decimal? GiaTri { get; set; }
        public decimal? GiaTriCon { get; set; }
    }
}
