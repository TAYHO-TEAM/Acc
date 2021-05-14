using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_Phat_NhomResponseViewModel : BaseResponseAccountInfoViewModel
    {
        public string TenNhomPhat { get; set; }
        public string DienGiai { get; set; }
        public int? SortIndex { get; set; }
    }
}
