using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Api.ViewModels.BaseClasses
{
    public class BaseResponseViewModel : DTOBase
    {
    }
    public class BaseResponseChilCountViewModel : DTOChilCountBase
    {
    }

    public class BaseResponseAccountInfoViewModel : DTOChilCountBase
    {
        public string CreateBy_Name { get; set; }
        public byte[] CreateBy_Avartar { get; set; }
        public string CreateBy_Title { get; set; }
        public string CreateBy_Department { get; set; }

        public string ModifyBy_Name { get; set; }
        public byte[] ModifyBy_Avartar { get; set; }
        public string ModifyBy_Title { get; set; }
        public string ModifyBy_Department { get; set; }
    }
    public class BaseResponseAccountInfoPermitViewModel : BaseResponseAccountInfoViewModel
    {
        public int PermistionId { get; set; }
    }
}
