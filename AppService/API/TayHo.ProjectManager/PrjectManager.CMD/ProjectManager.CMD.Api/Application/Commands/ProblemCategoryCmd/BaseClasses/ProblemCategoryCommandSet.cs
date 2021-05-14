namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ProblemCategoryCommandSet : BaseCommandClasses
    {
        public string Title { get; set; }
        public string Descriptions { get; set; }
        public byte? Priotity { get; set; }
    }
}