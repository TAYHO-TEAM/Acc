using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CustomFormContentCommandSet : BaseCommandClasses
    {
        public string Code { get; set; }
        public int? CustomFormId { get; set; }
    }
}