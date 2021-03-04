using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Utilities
{
    public class RequestOBJ
    {
        public int? Id { get; set; }
        public int? PlanRegisterId { get; set; }
        public string Code { get; set; }
        public string BarCode { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public string Note { get; set; }
        public int? ParentId { get; set; }
        public int? Level { get; set; }
        public byte? NoAttachment { get; set; }
        public int? ProjectId { get; set; }
        public int? WorkItemId { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? Rev { get; set; }
        public string token { get; set; }

    }
}