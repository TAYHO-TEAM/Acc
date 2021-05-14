using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class CustomFormBodyDTO : DTOBase
    {
        public byte? Priority { get; set; }
        public string Header { get; set; }
        public int? CustomTableId { get; set; }
        public int? CustomFormId { get; set; }
    }
    public class CustomFormBodyDetailDTO : CustomFormBodyDTO
    {
        public CustomTableDetailDTO CustomTableDetailDTO { get; set; } = new CustomTableDetailDTO();

    }
}
