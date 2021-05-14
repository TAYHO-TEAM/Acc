using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class PlanAccountDTO : DTOBase
    {
        public int? AccountId { get; set; }
        public int? GroupId { get; set; }
        public int? PermistionId { get; set; }
        public int? OwnerById { get; set; }
        public string OwnerTable { get; set; }
    }
}
