using System;
namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_TamUng_TheoDoiCommandSet : BaseCommandClasses
    {
        public int? TamUngId { get; set; }
        public string NoiDung { get; set; }
        public string DienGiai { get; set; }
        public decimal? GiaTri { get; set; }
        public int? Dot { get; set; }
    }
}