using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Utilities
{
    public class DefectFixOBJ
    {

        public int? DefectFeedbackId { get; set; }
        public string Fixer { get; set; }
        public string FixerPhone { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? FixedDate { get; set; }
        public string Result { get; set; }
        public int? ResultType { get; set; }
        public string Note { get; set; }
        public byte? Status { get; set; }
        public string token { get; set; }
        public int Key { get; set; }
    }
}