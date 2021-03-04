using System;
namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_DuChiCommandSet : BaseCommandClasses
    {
        public int? ProjectId { get; set; }
        public int? NhomCongViecId { get; set; }
        public int? GroupId { get; set; }
        public DateTime? ThoiGianBaoCao { get; set; }
        public DateTime? ThoiGianDuChi { get; set; }
        public decimal? GiaTri { get; set; }
    }
}