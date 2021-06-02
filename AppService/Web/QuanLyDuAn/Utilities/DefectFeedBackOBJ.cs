using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Utilities
{
    public class DefectFeedBackOBJ
    {

        public int? Key { get; set; }
        public int? ConstructionItemsId { get; set; }
        public int? RealEstateId { get; set; }
        public int? CustomerId { get; set; }
        public int? DefectiveId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public int? NoAttachment { get; set; }
        public byte? Status { get; set; }
        public string token { get; set; }

    }
}