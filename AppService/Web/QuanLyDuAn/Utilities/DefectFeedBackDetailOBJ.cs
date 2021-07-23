using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Utilities
{
    public class DefectFeedBackDetailOBJ
    {
        public int? Key { get; set; }
        public int? DefectiveId { get; set; }
        public int? DefectFeedbackId { get; set; }
        public string Note { get; set; }
        public byte? Status { get; set; }
        public string token { get; set; }
    }
}