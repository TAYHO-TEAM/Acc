using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DTOs
{
    public class AccountInfo : DOBase
    {
        public int? AccountId { get; set; }
        //public string AccountName { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public byte? Type { get; set; }
        public byte[]? AvatarImg { get; set; }

    }
}
