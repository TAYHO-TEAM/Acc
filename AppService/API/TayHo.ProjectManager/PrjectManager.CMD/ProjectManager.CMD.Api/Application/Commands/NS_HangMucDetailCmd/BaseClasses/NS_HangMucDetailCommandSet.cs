namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_HangMucDetailCommandSet : BaseCommandClasses
    {
        public int? HangMucId { get; set; }
        public int? ProjectId { get; set; }
        public int? GiaiDoanId { get; set; }
        public decimal? GiaTri { get; set; }
    }
}
