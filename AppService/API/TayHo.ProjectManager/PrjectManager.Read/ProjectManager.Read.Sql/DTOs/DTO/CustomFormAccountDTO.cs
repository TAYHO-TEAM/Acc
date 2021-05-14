using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class CustomFormAccountDTO : DTOBase
    {
        public int? CustomFormId { get; set; }
        public int? AccountId { get; set; }
        public int? GroupId { get; set; }
    }
}
