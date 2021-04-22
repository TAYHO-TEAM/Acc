using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDuAn.Utilities
{
    public class CongViecOBJ
    {
        public string nhom { get; set; }
        public string tenCongViec { get; set; }
        public string dienGiai { get; set; }
        public string dvt { get; set; }
        public decimal? donGia { get; set; }
        public decimal? khoiLuong { get; set; }
    }

    public class CongViecsOBJ
    {
        public List<CongViecOBJ> congViecOBJs { get; set; }
        public string token { get; set; }
    }
}