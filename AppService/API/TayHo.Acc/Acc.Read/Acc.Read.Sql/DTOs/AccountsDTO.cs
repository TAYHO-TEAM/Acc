using Acc.Read.Sql.DTOs.BaseClasses;
using System;

namespace Acc.Read.Sql.DTOs
{
    public class AccountsDTO : SysDTOBase
    {
        public string Code { get; set; }
        public byte? Type { get; set; }
        public string AccountName { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string TokenKey { get; set; }
        public DateTime? ExpiryTimeUTC { get; set; }
        public DateTime? ExpiryTime { get; set; }
        public string RefreshToken { get; set; }
        public int? UserId { get; set; }
    }
}
