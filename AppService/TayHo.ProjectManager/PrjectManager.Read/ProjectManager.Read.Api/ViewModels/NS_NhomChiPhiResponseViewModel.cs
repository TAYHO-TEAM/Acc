using ProjectManager.Read.Api.ViewModels.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NS_NhomChiPhiResponseViewModel : BaseResponseViewModel
    {
        public string TenNhomChiPhi { get; set; }
        public string DienGiai { get; set; }
        public int? SortIndex { get; set; }
    }
}
