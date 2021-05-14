using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class StepsProcessDTO : DTOBase
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public byte? Priority { get; set; }
        public int? ParentId { get; set; }
        public int? Level { get; set; }
        public int? PreviousId { get; set; }
        public int? NextId { get; set; }
        public int? OperationProcessId { get; set; }
    }
}
