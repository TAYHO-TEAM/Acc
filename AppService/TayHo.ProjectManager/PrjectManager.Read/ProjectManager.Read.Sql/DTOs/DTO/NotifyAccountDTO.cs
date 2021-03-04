using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NotifyAccountDTO : DTOBase
    {
        public int? AccountId { get; set; }
        public int? GroupId { get; set; }
        public int? NotifyId { get; set; }
        public DateTime? PushTime { get; set; }
    }
}
