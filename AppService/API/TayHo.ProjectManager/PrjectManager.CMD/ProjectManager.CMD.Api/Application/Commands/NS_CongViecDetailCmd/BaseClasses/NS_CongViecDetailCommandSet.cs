using System;
namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_CongViecDetailCommandSet : BaseCommandClasses
    { 
        public int? CongViecId { get; set; }
        public int? GiaiDoanId { get; set; }
        public int? ReasonId { get; set; }
        public decimal? DonGia { get; set; }
        public decimal? KhoiLuong { get; set; }
    }
}