using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Utilities
{
    public class CustomCellContentOBJ
    {
        public int? CustomFormContentId { get; set; }
        public int? CustomFormBodyId { get; set; }
        public int? CustomColumId { get; set; }
        public string Contents { get; set; }
        public int? NoRown { get; set; }

    }
    public class modelPVCustomTable
    {
        public int id { get; set; }
        public string code { get; set; }
    }
}