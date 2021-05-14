using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CustomFormCommandSet : BaseCommandClasses
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string Style { get; set; }
    }
}