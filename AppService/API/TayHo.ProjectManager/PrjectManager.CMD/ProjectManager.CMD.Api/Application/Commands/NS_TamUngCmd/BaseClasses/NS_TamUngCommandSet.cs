
using System;
namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_TamUngCommandSet : BaseCommandClasses
    {
        public int? GoiThauId { get; set; }
        public int? ProjectId { get; set; }
        public string NoiDung { get; set; }
        public string DienGiai { get; set; }
        public decimal? GiaTri { get; set; }
        public decimal? GiaTriCon { get; set; }
    }
}