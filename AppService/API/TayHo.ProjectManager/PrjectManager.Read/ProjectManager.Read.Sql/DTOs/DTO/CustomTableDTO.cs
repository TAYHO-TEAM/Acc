using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class CustomTableDTO : DTOBase
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int? NoColum { get; set; }
        public int? NoRown { get; set; }
        public string Style { get; set; }
        public int? Priority { get; set; }
    }
    public class CustomTableDetailDTO : CustomTableDTO
    {
        public List<CustomColumDetailDTO> CustomColumDetailDTOs { get; set; } = new List<CustomColumDetailDTO>();
    
    }
}
