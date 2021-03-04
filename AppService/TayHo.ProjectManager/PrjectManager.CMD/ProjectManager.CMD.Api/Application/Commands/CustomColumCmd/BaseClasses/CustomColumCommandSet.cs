using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CustomColumCommandSet : BaseCommandClasses
    {
        public int? CustomTableId { get; set; }
        public int? ColIndex { get; set; }
        public string Header { get; set; }
        public string TypeParam { get; set; }
        public string Style { get; set; }
        public string SourceValue { get; set; }
        public string SourceLink { get; set; }
    }
}