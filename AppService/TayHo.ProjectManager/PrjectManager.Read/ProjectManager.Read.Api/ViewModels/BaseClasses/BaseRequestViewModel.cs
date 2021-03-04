using ProjectManager.Read.Sql.Parameters;
using Services.Common.Paging;

namespace ProjectManager.Read.Api.ViewModels.BaseClasses
{
    public class BaseRequestViewModel : QueryPaging
    {
        public string FindParentId { get; set; }
        public string FindId { get; set; }
        public string SortCol { get; set; }
        public string SortADSC { get; set; }
        public string KeyWord { get; set; }
        public string ColumName { get; set; }
    }
    public class BaseTreeRequestViewModel : BaseRequestViewModel
    {
        public byte? TypeStore { get; set; }
    }
    public class BasePermitRequestViewModel : BaseRequestViewModel
    {
        public int? Type { get; set; }
    }
}
