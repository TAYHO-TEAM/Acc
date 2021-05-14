using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class NS_HangMucDetailDTO : DTOChilCountBase
    {
        public int? HangMucId { get; set; }
        public int? GiaiDoanId { get; set; }
        public int? ProjectId { get; set; }
        public decimal? GiaTri { get; set; }
    }
}
