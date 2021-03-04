using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Utilities
{
    public class PlanReport
    {
        public int? PlanMasterId { get; set; }
        public int? PlanJobId { get; set; }
        public string Content { get; set; }
        public string Unit { get; set; }
        public int? Amount { get; set; }
    }
}