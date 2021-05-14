using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class SysJobDTO : DTOBase
    {
        public int? TemplateId { get; set; }
        public string JobName { get; set; }
        public string NameDataBase { get; set; }
        public string NameStoreProce { get; set; }
        public string ConnStringHash { get; set; }
        public string Salt { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? FirstDate { get; set; }
        public DateTime? LastDate { get; set; }
        public DateTime? NextDate { get; set; }
        public int? Times { get; set; }
        public byte? Unit { get; set; }
        public int? StepTime { get; set; }
        public bool? IsTemplate { get; set; }
    }

    public class SysJobDataBaseDTO
    {
        public string name { get; set; }
    }
    public class SysJobStoreProcedureDTO
    {
        public string name { get; set; }
    }
    public class SysJobParameterDTO
    {
        public string ParameterName { get; set; }
        public string Type { get; set; }
        public int Length { get; set; }
        public int Prec { get; set; }
        public int Scale { get; set; }
        public int ParamOrder { get; set; }
        public string Collation { get; set; }

    }

}
