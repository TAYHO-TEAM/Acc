using ProjectManager.CMD.Api.Application.Commands;
using System;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_NghiemThuCommandSet : BaseCommandClasses
    {
        public int? CongViecDetailId { get; set; }
        public int? GoiThauId { get; set; }
        public int? GiaiDoanId { get; set; }
        public int? Dot { get; set; }
        public double? KhoiLuong { get; set; }
    }
}
