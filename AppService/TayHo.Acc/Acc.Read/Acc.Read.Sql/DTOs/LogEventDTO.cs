using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class LogEventDTO : DTOAccountInfoBase
    {
        public int? UserId { get; set; }
        public string Event { get; set; }
        public string Action { get; set; }
        public int? OwnerById { get; set; }
        public string OwnerByTable { get; set; }
        public int? FunctionId { get; set; }
        public string Message { get; set; }
    }
}
