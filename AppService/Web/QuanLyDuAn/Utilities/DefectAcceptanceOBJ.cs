using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Utilities
{
    public class DefectAcceptanceOBJ
    {

        public int? Key { get; set; }
        public int? Type { get; set; }
        public int? DefectFixId { get; set; }
        public int? DefectFeedbackId { get; set; }
        public int? DefectFeedbackDetailId { get; set; }
        public int? CustomerInfoId { get; set; }
        public string Note { get; set; }
        public int? NoAttachment { get; set; }
        public string token { get; set; }

    }
}