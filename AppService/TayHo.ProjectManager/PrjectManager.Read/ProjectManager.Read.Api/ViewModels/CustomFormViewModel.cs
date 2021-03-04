using ProjectManager.Read.Api.ViewModels.BaseClasses;
using ProjectManager.Read.Sql.DTOs.DTO;
using System.Collections.Generic;

namespace ProjectManager.Read.Api.ViewModels
{
    public class CustomFormResponseViewModel : BaseResponseViewModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string Style { get; set; }
    }
    public class CustomFormDetailResponseViewModel : CustomFormDetailDTO
    {
      
    }
  
}
