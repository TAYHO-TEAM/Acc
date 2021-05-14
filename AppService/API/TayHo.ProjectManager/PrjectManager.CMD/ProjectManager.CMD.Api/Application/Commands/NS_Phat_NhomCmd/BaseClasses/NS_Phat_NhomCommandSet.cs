using System;
namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_Phat_NhomCommandSet : BaseCommandClasses
    {
        public string TenNhomPhat { get; set; }
        public string DienGiai { get; set; }
        public int? SortIndex { get; set; }
    }
}