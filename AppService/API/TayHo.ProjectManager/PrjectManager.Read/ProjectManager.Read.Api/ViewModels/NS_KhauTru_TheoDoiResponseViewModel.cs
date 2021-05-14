using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_KhauTru_TheoDoiResponseViewModel : BaseResponseAccountInfoViewModel
    {
        public int? KhauTruId { get; set; }
        public string NoiDung { get; set; }
        public string DienGiai { get; set; }
        public decimal? GiaTri { get; set; }
        public int? Dot { get; set; }
    }
}
