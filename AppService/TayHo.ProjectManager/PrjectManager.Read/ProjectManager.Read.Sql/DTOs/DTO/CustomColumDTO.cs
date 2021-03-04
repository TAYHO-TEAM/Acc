using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class CustomColumDTO : DTOBase
    {
        public int? CustomTableId { get; set; }
        public int? ColIndex { get; set; }
        public string Header { get; set; }
        public string TypeParam { get; set; }
        public string Style { get; set; }
        public string SourceValue { get; set; }
        public string SourceLink { get; set; }
    }
    public class CustomColumDetailDTO : CustomColumDTO
    {
        public CustomColumDetailDTO()
        {
            CustomCellContentDTOs = new List<CustomCellContentDTO>();
        }
        public List<CustomCellContentDTO> CustomCellContentDTOs { get; set; }
    }
}
