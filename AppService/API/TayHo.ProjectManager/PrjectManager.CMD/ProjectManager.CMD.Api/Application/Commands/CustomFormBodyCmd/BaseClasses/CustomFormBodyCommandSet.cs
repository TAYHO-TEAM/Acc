using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CustomFormBodyCommandSet : BaseCommandClasses
    {
        public byte? Priority { get; set; }
        public string Header { get; set; }
        public int? CustomTableId { get; set; }
        public int? CustomFormId { get; set; }
    }
}