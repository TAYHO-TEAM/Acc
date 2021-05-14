namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_NhomCongViecDetailCommandSet : BaseCommandClasses
    {
        public int? NhomCongViecId { get; set; }
        public int? GiaiDoanId { get; set; }
        public decimal? GiaTri { get; set; }
        public int? SortIndex { get; set; }
    }
}