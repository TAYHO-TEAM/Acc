using Acc.Read.Sql.DTOs.BaseClasses;
using System;

namespace Acc.Read.Sql.DTOs
{
    public class UserInfoDTO : SysDTOBase
    {
        public string AvatarImg { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte? Sex { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
