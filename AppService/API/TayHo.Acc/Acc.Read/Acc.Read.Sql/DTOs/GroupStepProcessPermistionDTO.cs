using Acc.Read.Sql.DTOs.BaseClasses;

namespace Acc.Read.Sql.DTOs
{
    public class GroupStepProcessPermistionDTO : SysDTOBase
    {
        public int? GroupId { get; set; }
        public int? StepProcessId { get; set; }
        public int? Permistion { get; set; }
    }
}
