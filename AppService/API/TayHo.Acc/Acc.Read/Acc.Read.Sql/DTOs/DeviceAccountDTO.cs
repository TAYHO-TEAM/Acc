using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class DeviceAccountDTO : SysDTOBase
    {
        public string Device { get; set; }
        public int? AccountId { get; set; }
        public string DeviceToken { get; set; }
        public string Browser { get; set; }
    }
}
