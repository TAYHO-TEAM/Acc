using System;
namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_ThucChiCommandSet : BaseCommandClasses
    {
        public int? NhomCongViecId { get; set; }
        public int? GoiThauId { get; set; }
        public string ThangBaoCao { get; set; }
        public string ThangThucChi { get; set; }
        public decimal? GiaTri { get; set; }
    }
}