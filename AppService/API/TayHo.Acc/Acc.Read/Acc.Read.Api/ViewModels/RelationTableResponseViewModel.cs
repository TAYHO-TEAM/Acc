using Acc.Read.Api.ViewModels.BaseClasses;

namespace Acc.Read.Api.ViewModels
{
    public class RelationTableResponseViewModel : BaseResponseViewModel
    {
        public string PrimaryTable { get; set; }
        public string PrimaryKey { get; set; }
        public string ForeignTable { get; set; }
        public string ForeignKey { get; set; }
    }
}
