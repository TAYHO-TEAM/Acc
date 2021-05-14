using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class PlanRegisterDTO : DTOBase
    {
        public int? ParentId { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? WorkItemId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int? ProjectId { get; set; }
        public int? ContractorInfoId { get; set; }
        public string Description { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public DateTime? ExpectRequestDate { get; set; }
        public DateTime? ExpectResponseDate { get; set; }
    }
    public class PlanRegisterChilDTO : DTOChilCountBase
    {
        public int? ParentId { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? WorkItemId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int? ProjectId { get; set; }
        public int? ContractorInfoId { get; set; }
        public string Description { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public DateTime? ExpectRequestDate { get; set; }
        public DateTime? ExpectResponseDate { get; set; }
    }
}
