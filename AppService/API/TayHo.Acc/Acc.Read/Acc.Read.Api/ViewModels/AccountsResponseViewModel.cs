using Acc.Read.Api.ViewModels.BaseClasses;
using System;

namespace Acc.Read.Api.ViewModels
{
    public class AccountsResponseViewModel : BaseResponseViewModel
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
