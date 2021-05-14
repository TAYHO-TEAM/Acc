using System;
namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_Phat_TheoDoiCommandSet : BaseCommandClasses
    {
        public int? PhatId { get; set; }
        public string NoiDung { get; set; }
        public string DienGiai { get; set; }
        public decimal? GiaTri { get; set; }
        public int? Dot { get; set; }
    }
}