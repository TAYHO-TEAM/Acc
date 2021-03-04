using ProjectManager.Read.Api.ViewModels.BaseClasses;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.ViewModels
{
    public class CustomFormContentResponseViewModel : BaseResponseViewModel
    {
        public string Code { get; set; }
        public int? CustomFormId { get; set; }
    }
    public class CustomFormContentDetailResponseViewModel : CustomFormContentDetailDTO
    {

    }
}
