using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CustomTableCommandSet : BaseCommandClasses
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int? NoColum { get; set; }
        public int? NoRown { get; set; }
        public string Style { get; set; }
        public int? Priority { get; set; }
    }
}