using ProjectManager.Read.Sql.DTOs.BaseClasses;
using System;
using System.Collections.Generic;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class RequestRegistDTO : DTOChilCountBase
    {
        public string Code { get; set; }
        public string BarCode { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string Note { get; set; }
        public int? ParentId { get; set; }
        public int? PlanRegisterId { get; set; }
        public int? Level { get; set; }
        public byte? NoAttachment { get; set; }
        public int? ProjectId { get; set; }
        public int? WorkItemId { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? Rev { get; set; }
        public bool? Insert { get; set; }
        public bool? Update { get; set; }
        public bool? Delete { get; set; }
        public bool? View { get; set; }
        public string AccountName { get; set; }
    }
    public class RequestRegistDetailDTO : RequestRegistDTO
    {
        public RequestRegistDetailDTO()
        {
            ResponseRegistDTOs = new List<ResponseRegistDTO>();
        }
        public DateTime? RequestDate { get; set; }
        public DateTime? ResponseDate { get; set; }
        public DateTime? ExpectRequestDate { get; set; }
        public DateTime? ExpectResponseDate { get; set; }
        public List<ResponseRegistDTO> ResponseRegistDTOs { get; set; }
    }
}
