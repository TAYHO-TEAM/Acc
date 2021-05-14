using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DTOs
{
    public class DocumentReleasedLogDetail
    {

        public int? DRId { get; set; }
        public string DRCode { get; set; }
        public string DRTitle { get; set; }
        public string DRDescription { get; set; }
        public int? DRDocumentTypeId { get; set; }
        public int? DRProjectId { get; set; }
        public int? DRWorkItemId { get; set; }
        public string DRTagWorkItem { get; set; }
        public string DRLocation { get; set; }
        public DateTime? DRCalendar { get; set; }
        public byte? DRNoAttachment { get; set; }
        public bool? DRIsDelete { get; set; }
        public bool? DRIsActive { get; set; }
        public bool? DRIsVisible { get; set; }
        public bool? DRIsModify { get; set; }
        public int? DRCreateBy { get; set; }
        public DateTime? DRCreateDateUTC { get; set; }
        public DateTime? DRCreateDate { get; set; }
        public int? DRModifyBy { get; set; }
        public DateTime? DRUpdateDateUTC { get; set; }
        public DateTime? DRUpdateDate { get; set; }
        public byte? DRStatus { get; set; }
        [Key]
        public int? DRLId { get; set; }
        public int? DRLAccountId { get; set; }
        public int? DRLDocumentReleasedId { get; set; }
        public string DRLNote { get; set; }
        public bool? DRLIsDelete { get; set; }
        public bool? DRLIsActive { get; set; }
        public bool? DRLIsVisible { get; set; }
        public bool? DRLIsModify { get; set; }
        public int? DRLCreateBy { get; set; }
        public DateTime? DRLCreateDateUTC { get; set; }
        public DateTime? DRLCreateDate { get; set; }
        public int? DRLModifyBy { get; set; }
        public DateTime? DRLUpdateDateUTC { get; set; }
        public DateTime? DRLUpdateDate { get; set; }
        public byte? DRLStatus { get; set; }
        public int? CreateBy{get; set;}
        public bool? IsDelete { get; set; }
    }
}
