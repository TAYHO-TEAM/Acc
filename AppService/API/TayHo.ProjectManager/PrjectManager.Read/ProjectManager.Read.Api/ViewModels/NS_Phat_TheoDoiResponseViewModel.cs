using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_Phat_TheoDoiResponseViewModel : BaseResponseAccountInfoViewModel
    {
        public int? PhatId { get; set; }
        public string NoiDung { get; set; }
        public string DienGiai { get; set; }
        public decimal? GiaTri { get; set; }
        public int? Dot { get; set; }
    }
}
